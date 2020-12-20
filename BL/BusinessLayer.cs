﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BlApi;
using DaLApi;
using BO;


namespace BL
{
    class BusinessLayer : IBL
    {
        IDAL dal = DalFactory.GetDal();
        public IEnumerable<BO.Bus> presentAllBus()
        {

            List<BO.Bus> allBuses = new List<BO.Bus>();// = dal.getAllBuses() ;//.Where(x => x == x) ; 
            foreach (var item in dal.getAllBuses())
            {
                string a = item.Id.Replace("-","");
                allBuses.Add(new BO.Bus(a,item.StartDate));
            }
            allBuses[0].InDriving = true;
            return allBuses;
        }

       public bool canDrive(BO.Bus bus, ref string mes)
        {
            if (bus.InTreamant)
            {
               mes="bus " + bus.Id + " busy in treatment";
                return false;
            }
            else if (bus.InRefule)
            {
                mes = "bus " + bus.Id + " busy in refule";
                return false;
            }
            else if (bus.InDriving)
            {
                mes="bus number " + bus.Id + " in driving now";
                return false;
            }
            // if all conditon alow it, sanding the bus
            else
            {
                return true;
               
            }
        }

        public bool canDrive(BO.Bus bus, ref string mes, string kM)
        {
            if (bus.Gas - int.Parse(kM) <= 0)
            {
                mes =("there is no enough gas fo driving");
                return false;
            }
            else if (((bus.LsaatTreastKm) + int.Parse(kM)) > 20000)
            {
                mes ="you need take the bus to treatment, over km treatment";
                return false;
            }
            else if ((CheckingDate(bus.LastTreatDate.ToString())))
            {
                mes ="over a year past since the last treatment";
                return false;
            }
             // if all the condition is ok take drive and update the right fildes
            else
            {

                Random k = new Random();
                double trip_time = double.Parse(kM) / k.Next(20, 50);
                Thread t3 = new Thread(
                    () =>
                    {

                        bus.InDriving = true;


                        bus.SeePro = "Visible";
                        bus.Color = "#00FFFF";
                        bus.Regull = 0;
                        //Action action1 = () => ((MainWindow)Application.Current.MainWindow).bus_list.Items.Refresh();
                        //Dispatcher.BeginInvoke(action1);
                        for (int i = 0; i < 100; i++)
                        {
                            bus.refull += 1;

                            Thread.Sleep((int)trip_time * 6000 / 100);
                            //Action action2 = () => ((MainWindow)Application.Current.MainWindow).bus_list.Items.Refresh();
                            //Dispatcher.BeginInvoke(action2);
                        }
                        bus.Color = "";
                        bus.InDriving = false;
                        bus.SeePro = "Hidden";
                        //MessageBox.Show("bus number " + busToDriv.Id + " finish his trip");
                    }
                    );
                t3.Start();
                bus.Km += int.Parse(kM);
                bus.LsaatTreastKm += int.Parse(kM);
                bus.Gas -= int.Parse(kM);
                //((MainWindow)Application.Current.MainWindow).bus_list.Items.Refresh();
                //Close();
                return true;
            }

        }

       public bool Refuell(BO.Bus bus, ref string mes)
        {
            if (bus.Gas==1200)
            {
                mes = "The fuel is already full";
                return false;
            }
            else
            {
                bus.Gas = 1200;
                return true;
            }
        }


        /// <summary>
        /// function that checking if past over a year 
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        bool CheckingDate(string strDate)
            {
                DateTime date1stDate = Convert.ToDateTime(strDate);
                DateTime dateToday = DateTime.Now.Date;

                TimeSpan ts = dateToday - date1stDate;
                int days = ts.Days;
                if (days < 365)
                    return false;
                return true;
            }

       public static bool isUser(string userName, string password)
        {
           return  dal.dalIsUser( userName,  password);
        }
    }
    }
