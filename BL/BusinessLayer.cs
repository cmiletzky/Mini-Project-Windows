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
using System.Data;
using System.Collections.ObjectModel;

namespace BL
{
    class BusinessLayer : IBL
    {
        public static IDAL dal = DalFactory.GetDal();
        void IBL.InitializeData()
        {
            dal.InitializeData();
        }
        bool IBL.CheckAdjacentStatision(int stop1, int stop2)
        {
            return dal.CheckAdjacentStatision(stop1,stop2);
        }
        void IBL.AddStopLine(int stopNum, int lineNum, int after)
        {
            if (dal.GetStopsOfLine().Any(x=>x.OfLine==lineNum&&x.Id==stopNum))
            {
                throw new Exception("התחנה כבר קיימת בקו");
            }
            else
            {
                dal.AddStopOfLine(stopNum,lineNum,after);
            }
        }
        void IBL.RemoveStopFromLine(int lineNum, int stopCode)
        {
            //TODO לטפל ברשימה ריקה(למנוע כפתור)
            var stopTo = (from item in dal.GetStopsOfLine()
                         where item.OfLine == lineNum && item.Id == stopCode
                         select item).ToList().First();
       
            dal.RemoveStopLine(stopTo);
        }
        IEnumerable<Station> IBL.presentStopsOfLine(int lineNum)
        {
            var stops = (from item1 in dal.GetStopsOfLine()
                         from item2 in dal.getStations(false)
                         where item1.OfLine == lineNum && item1.Id == item2.Code
                         select item2).ToList();

            List<Station> listTo = new List<Station>();

            foreach (var item in stops)
            {
                listTo.Add(new Station(item.Code, item.Name, item.Longtitude, item.Latitude));
            }
            return listTo;
        }
        public IEnumerable<Bus> presentAllBus(bool run)
        {

            List<Bus> allBuses = new List<Bus>();// = dal.getAllBuses() ;//.Where(x => x == x) ; 
            foreach (var item in dal.getAllBuses(run))
            {
                string a = item.Id.Replace("-", "");
                if (item.IsActive != false)
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
            bus.LsaatTreastKm = busToUpdate.LsaatTreastKm;
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

        public bool isUserMang(string userName, string password, bool isMang)
        {
            return dal.dalIsUser(userName, password, isMang);
        }

        public IEnumerable<Station> presentAllStation(bool run)
        {

            List<Station> list = new List<Station>();
            if (run == true)
            {
                foreach (var item in dal.getStations(run))
                {
                    list.Add(new Station(item.Code, item.Name, item.Longtitude, item.Latitude));

                }
            }
            else
            {
                foreach (var item in dal.getStations(run))
                {
                    list.Add(new Station(item.Code, item.Name, item.Longtitude, item.Latitude));

                }
            }

            return list;
        }
        public IEnumerable<LineBus> presentAllLines(bool run)
        {
            var lines = (from item in dal.getLins(true)
                        where item.IsActive == true
                        select (new LineBus(item.LineNum, GetAreas(item.Area), item.FirstStation, item.LastStation))).ToList();

            foreach (var item in lines)
            {
                item.Stops = (from item1 in dal.GetStopsOfLine()
                             from item2 in dal.getStations(false)
                             where item1.OfLine == item.LineNum && item1.Id == item2.Code
                             select new Station(item2.Code, item2.Name, item2.Longtitude, item2.Latitude ,item1.StatIndex)).ToList<Station>();

                for (int i = 1; i < item.Stops.Count(); i++)
                {
                    item.Stops.ElementAt(i).PriviosStop = item.Stops.ElementAt(i - 1);
                }
                item.Stops.ElementAt(0).PriviosStop = item.Stops.ElementAt(item.Stops.Count()-1);
                item.AdjacentStatisions = (from bb in item.Stops
                                           from aa in dal.getAdjacentStatisions()
                                           where aa.Station_1== bb.PriviosStop.Code && aa.Station_2== bb.Code
                                           select aa).ToList<DO.AdjacentStatision>();

                for (int i = 1; i < item.Stops.Count(); i++)
                {
                    item.Stops.ElementAt(i).TimeFromPrivios = (from ee in item.AdjacentStatisions
                                                              where ee.Station_2 == item.Stops.ElementAt(i).Code
                                                              select ee.Time).First();

                    item.Stops.ElementAt(i).DistanceFromPrivios = (from ee in item.AdjacentStatisions
                                                               where ee.Station_2 == item.Stops.ElementAt(i).Code
                                                               select ee.Distance).First();
                }
            }
            return lines;
        }
        Areas GetAreas(DO.Areas a)
        {
            switch (a)
            {
                case DO.Areas.General:
                    return Areas.General;
                    break;
                case DO.Areas.North:
                    return Areas.North;
                    break;
                case DO.Areas.South:
                    return Areas.South;
                    break;
                case DO.Areas.Center:
                    return Areas.Center;
                    break;
                case DO.Areas.Jerusalem:
                    return Areas.Jerusalem;
                    break;
                default:
                    return Areas.General;
                    break;
            }
        }
        // public ObservableCollection<StopOfLine> initializeStopsLine(DO.LineBus item) 
        //{
        //    ObservableCollection<StopOfLine> list = new ObservableCollection<StopOfLine>();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        StopOfLine stop = new StopOfLine(item.LineNum, item.StationList[i], i);
        //        foreach (var st in dal.getStations(false))
        //        {
        //            if (st.Code==stop.Id)
        //            {
        //                stop.Stop = new Station(st.Code, st.Name, st.Longtitude, st.Latitude); ;
        //            }
        //        }
        //        list.Add(stop); 
        //    }
        //    return list;
        //}

        void IBL.RemoveLine(LineBus lineBus)
        {
            dal.RemoveLine(lineBus.LineNum);
        }

        void IBL.AddStation(string code, string name, string longtitude, string latitude)
        {

            try
            {
                dal.addStation(int.Parse(code), name, int.Parse(longtitude), int.Parse(latitude));
            }
            catch (DuplicateNameException)
            {

                throw;
            }
        }
    }
}
