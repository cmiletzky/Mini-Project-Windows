using System;
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
        public static IDAL dal = DalFactory.GetDal();
        public IEnumerable<Bus> presentAllBus()
        {

            List<Bus> allBuses = new List<Bus>();// = dal.getAllBuses() ;//.Where(x => x == x) ; 
            foreach (var item in dal.getAllBuses())
            {
                string a = item.Id.Replace("-", "");
                allBuses.Add(new Bus(a, item.StartDate));
            }
            allBuses[0].InDriving = true;
            return allBuses;
        }

        public bool canDrive(Bus bus, ref string mes)
        {
            if (bus.InTreamant)
            {
                mes = "bus " + bus.Id + " busy in treatment";
                return false;
            }
            else if (bus.InRefule)
            {
                mes = "bus " + bus.Id + " busy in refule";
                return false;
            }
            else if (bus.InDriving)
            {
                mes = "bus number " + bus.Id + " in driving now";
                return false;
            }
            // if all conditon alow it, sanding the bus
            else
            {
                return true;

            }
        }

        public bool canDrive(Bus bus, ref string mes, string kM)
        {
            if (bus.Gas - int.Parse(kM) <= 0)
            {
                mes = ("there is no enough gas fo driving");
                return false;
            }
            else if (((bus.LsaatTreastKm) + int.Parse(kM)) > 20000)
            {
                mes = "you need take the bus to treatment, over km treatment";
                return false;
            }
            else if ((CheckingDate(bus.LastTreatDate.ToString())))
            {
                mes = "over a year past since the last treatment";
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

        public bool Refuell(Bus bus, ref string mes)
        {
            if (bus.Gas == 1200)
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

        public bool isUser(string userName, string password)
        {
            return dal.dalIsUser(userName, password);
        }

       public IEnumerable<Station> presentAllStation()
        {
         
            List<Station> list = new List<Station>();
            foreach (var item in dal.getStations())
            {
                list.Add(new Station(item.Code, item.Name, item.Longtitude,item.Latitude));
              
            }
            return list;
        }
       public IEnumerable<Line> presentAllLines()
        {
            List<Line> lines = new List<Line>();
            foreach (var item in dal.getLins())
            {
                //TODO לטפל באיתחול אזור
                lines.Add(new Line(item.LineNum,1, item.FirstStation, item.LastStation,initializeStops(item)));
            }
            return lines;
        }

         public  List<StopOfLine> initializeStops(DO.Line item) 
        {
            List<StopOfLine> list = new List<StopOfLine>();
            for (int i = 0; i < 10; i++)
            {
               // List<int> gg = from item in dal.getStations() where item.Code == j[i] select item.Code;
                list.Add(new StopOfLine(item.Id, item.StationList[i], i)); ;
            }
            return list;
        }
    }
}
