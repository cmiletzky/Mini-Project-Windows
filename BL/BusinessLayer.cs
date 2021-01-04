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

        #region line

        void IBL.RemoveStopLine(int code)
        {
            dal.RemoveStopLine(code);
        }
        LineBus IBL.presentLine(int lineNum)
        {
            return (from line in dal.getLins()
                   where line.LineNum == lineNum
                   select new LineBus(line.LineNum,GetAreas(line.Area),line.FirstStation,line.LastStation)).First();
        }
        void IBL.AddLine(int newLineNum, string area, int firstStop, int lastStop)
        {
            if (dal.getLins().Any(x => x.LineNum == newLineNum))
            {
                throw new Exception("מספר הקו כבר קיים");
            }

           

            dal.AddLine(newLineNum,area,firstStop,lastStop);
            dal.AddAdjacentStatision(firstStop, lastStop,"0", new TimeSpan());
            dal.AddStopOfLine(firstStop, newLineNum, 1);
            dal.AddStopOfLine(lastStop, newLineNum, 2);

        }



        IEnumerable<LineBus> IBL.presentAllLines(bool run)
        {
            var lines = (from item in dal.getLins()
                         where item.IsActive == true
                         select (new LineBus(item.LineNum, GetAreas(item.Area), item.FirstStation, item.LastStation))).ToList();

            foreach (var item in lines)
            {
                item.Stops = (from item1 in dal.GetStopsOfLine()
                              from item2 in dal.getStations()
                              where item1.OfLine == item.LineNum && item1.Id == item2.Code
                              select new Station(item2.Code, item2.Name, item2.Longtitude, item2.Latitude, item1.StatIndex)).OrderBy(x => x.IndexInLine).ToList<Station>();
                item.Stops[0].IsNotFirst = false;
                TimeSpan counTime = new TimeSpan(00, 00, 00);
                double counDis = 0;
                for (int i = 1; i < item.Stops.Count(); i++)
                {
                    try
                    {
                        counTime += (from rr in dal.getAdjacentStatisions()
                                     where rr.Station_2 == item.Stops[i].Code
                                     && rr.Station_1 == item.Stops[i - 1].Code
                                     select rr.Time).First();
                        counDis += (from rr in dal.getAdjacentStatisions()
                                    where rr.Station_2 == item.Stops[i].Code
                                    && rr.Station_1 == item.Stops[i - 1].Code
                                    select rr.Distance).First();
                    }
                    catch (Exception)
                    {

                        dal.AddAdjacentStatision(item.Stops[i].Code, item.Stops[i - 1].Code, "0", new TimeSpan(00, 00, 00));

                    }

                    item.Stops[i].TimeFromBeginnig = counTime;
                    item.Stops[i].DistanceFromBeginnig = counDis;
                    item.Stops[i].TimeFromPrivios = item.Stops[i].TimeFromBeginnig - item.Stops[i - 1].TimeFromBeginnig;
                    item.Stops[i].DistanceFromPrivios = item.Stops[i].DistanceFromBeginnig - item.Stops[i - 1].DistanceFromBeginnig;
                }


            }
            return lines;
        }
        void IBL.CheckStopIsInLine(int stopNum, int lineNum)
        {
            if (dal.GetStopsOfLine().Any(x => x.OfLine == lineNum && x.Id == stopNum))
            {
                throw new Exception("התחנה כבר קיימת בקו");
            }
        }

        void IBL.EditLine(int oldLineNum, int lineNum, string area)
        {
            if (dal.getLins().Any(x => x.LineNum == lineNum && oldLineNum!= lineNum))
            {
                throw new Exception("מספר הקו כבר קיים");
            }
       
            dal.EditLine(oldLineNum, lineNum, area);
        }

        void IBL.AddStopLine(int stopNum, int lineNum, int after)
        {
            dal.AddStopOfLine(stopNum, lineNum, after);
        }
        void IBL.RemoveStopFromLine(int lineNum, int stopCode)
        {
            //TODO לטפל ברשימה ריקה(למנוע כפתור)
            var stopTo = (from item in dal.GetStopsOfLine()
                          where item.OfLine == lineNum && item.Id == stopCode
                          select item).ToList().First();

            dal.RemoveStopFromLine(stopTo);
        }
        List<Station> IBL.presentStopsOfLine(int lineNum)
        {
            var stops = (from item1 in dal.GetStopsOfLine()
                         from item2 in dal.getStations()
                         where item1.OfLine == lineNum && item1.Id == item2.Code
                         select item2).ToList();

            List<Station> listTo = new List<Station>();

            foreach (var item in stops)
            {
                listTo.Add(new Station(item.Code, item.Name, item.Longtitude, item.Latitude));
            }
            return listTo;
        } 
        IEnumerable<Station> IBL.presentStopsLine()
        {
            var a =  (from item2 in dal.getStations()
                    from item1 in dal.GetStopsOfLine()
                    where (item1.Id == item2.Code) 
                    select new Station(item2.Code,item2.Name,item2.Longtitude,item2.Latitude,item1.OfLine,1)).ToList();
            a.First().Latitude = 32.98117;
            a.First().Longtitude = 35.44093;

            a.ElementAt(13).Latitude = 31.51506 ;
            a.ElementAt(13).Longtitude = 34.43994 ;
            return a.GroupBy(x => x.Code).Select(t => t.FirstOrDefault());
        }

        void IBL.RemoveLine(LineBus lineBus)
        {
            dal.RemoveLine(lineBus.LineNum);
        }

        Areas GetAreas(DO.Areas a)
        {
            switch (a)
            {
                case DO.Areas.General:
                    return Areas.General;
                case DO.Areas.North:
                    return Areas.North;
                case DO.Areas.South:
                    return Areas.South;
                case DO.Areas.Center:
                    return Areas.Center;
                case DO.Areas.Jerusalem:
                    return Areas.Jerusalem;
                default:
                    return Areas.General;
            }
        }
        #endregion

        #region bus
        public IEnumerable<Bus> presentAllBus(bool run)
        {

            List<Bus> allBuses = new List<Bus>();// = dal.getAllBuses() ;//.Where(x => x == x) ; 
            foreach (var item in dal.getAllBuses())
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

        #endregion

        #region Station
        void IBL.RemoveStop(int code)
        {
            dal.RemoveStop(code);
        }
        IEnumerable<int> IBL.GetLinsInStop(int code)
        {
            return (from line in dal.GetStopsOfLine()
                    where line.Id == code
                    select line.OfLine).ToList().Distinct();
        }
        List<AdjacentStatision> IBL.GetAdjacentStatisionBefore(int code)
        {
            var list = (from AD in dal.getAdjacentStatisions()
                     from stop1 in dal.getStations()
                     from stop2 in dal.getStations()
                     where AD.Station_2 == code && stop1.Code == AD.Station_1 && stop2.Code == AD.Station_2
                     select new AdjacentStatision(AD.Station_1,AD.Station_2,stop1.Name,stop2.Name,AD.Distance,AD.Time)).ToList();

            return list;
        }
        List<AdjacentStatision> IBL.GetAdjacentStatisionAfter(int code)
        {
            var list = (from AD in dal.getAdjacentStatisions()
                        from stop1 in dal.getStations()
                        from stop2 in dal.getStations()
                        where AD.Station_1 == code && stop1.Code == AD.Station_1 && stop2.Code == AD.Station_2
                        select new AdjacentStatision(AD.Station_1, AD.Station_2, stop1.Name, stop2.Name, AD.Distance, AD.Time)).ToList();

            return list;
        }
        public IEnumerable<Station> presentAllStation(bool run)
        {

            List<Station> list = new List<Station>();
            if (run == true)
            {
                foreach (var item in dal.getStations())
                {
                    list.Add(new Station(item.Code, item.Name, item.Longtitude, item.Latitude));

                }
            }
            else
            {
                foreach (var item in dal.getStations())
                {
                    list.Add(new Station(item.Code, item.Name, item.Longtitude, item.Latitude));

                }
            }

            return list;
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



        #endregion

        #region AdjacentStatision
        void IBL.AddAdjacentStatision(int stop1, int stop2, string distnase, TimeSpan time)
        {
            dal.AddAdjacentStatision(stop1, stop2, distnase, time);
        }
        void IBL.EditAdjacentStatision(int stop1, int stop2, double dis, TimeSpan time)
        {
            dal.EditAdjacentStatision(stop1, stop2, dis, time);
        }
        bool IBL.CheckAdjacentStatision(int stop1, int stop2)
        {
            return dal.CheckAdjacentStatision(stop1, stop2);
        }
        #endregion

        #region User
     public   bool isUserMang(string userName, string password, bool isMang)
        {
            return dal.dalIsUser(userName, password, isMang);
        }
        #endregion
    }
}


       
