using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BlApi;
using DaLApi;
using BO;
using BL.BO;

namespace BL
{
    class BusinessLayer : IBL
    {
        public static IDAL dal = DalFactory.GetDal();
        public IEnumerable<Bus> presentAllBus(bool run)
        {

            List<Bus> allBuses = new List<Bus>();// = dal.getAllBuses() ;//.Where(x => x == x) ; 
            foreach (var item in dal.getAllBuses(run))
            {
                string a = item.Id.Replace("-", "");
                if (item.IsActive!=false)
                {
                    Bus bus = new Bus(a, item.StartDate);
                    bus.IsActive = item.IsActive;
                    bus.LastTreatDate = item.LastTreatDate;
                    bus.LsaatTreastKm = item.LsaatTreastKm;
                    bus.Gas = item.Gas;
                    bus.Km = item.Km;
                    bus.StartDate = item.StartDate;
                    allBuses.Add(bus);
                }
                
            }
           // allBuses[0].InDriving = true;
            return allBuses;
        }
        void IBL.updateBus(Bus busToUpdate)
        {
            string a = busToUpdate.Id.Replace("-", "");
            DO.Bus bus = new DO.Bus(a, busToUpdate.StartDate);
            bus.Km = busToUpdate.Km;
            bus.LsaatTreastKm =busToUpdate.LsaatTreastKm;
            bus.Gas = busToUpdate.Gas;
            bus.LastTreatDate = busToUpdate.LastTreatDate;
            dal.updateBus(bus);
        }
       public void RemoveBus(Bus busToRemove)
        {
            dal.DeleteBus(busToRemove.Id);
        }
        public void AddBus(string busNam, DateTime? startDate)
        {

            switch (dal.BusAlreadyExists(busNam))
            {
                case 0:
                 throw new Exception("The bus already exists in the system");
                   
                case 1:
                    dal.addBus(busNam, startDate);
                    break;
                case 2:
                    dal.activeBus(busNam);
                    break;
                default:
                    break;
            }
         
            
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
              //  Random k = new Random();
               // double trip_time = double.Parse(kM) / k.Next(20, 50);
                bus.InDriving = true;
                bus.Km += int.Parse(kM);
                bus.LsaatTreastKm += int.Parse(kM);
                bus.Gas -= int.Parse(kM);
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

        public bool isUserMang(string userName, string password ,bool isMang)
        {
            return dal.dalIsUser(userName, password,isMang);
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
       public IEnumerable<LineBus> presentAllLines()
        {
            List<LineBus> lines = new List<LineBus>();
            foreach (var item in dal.getLins())
            {
                //TODO לטפל באיתחול אזור
                lines.Add(new LineBus(item.LineNum,1, item.FirstStation, item.LastStation,initializeStopsLine(item)));
            }
            return lines;
        }

         public  List<StopOfLine> initializeStopsLine(DO.LineBus item) 
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
