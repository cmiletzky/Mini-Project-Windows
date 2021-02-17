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
        /// <summary>
        /// delete stop of line
        /// </summary>
        /// <param name="code">num of station to delete </param>
        void IBL.RemoveStopLine(int code)
        {
            dal.RemoveStopLine(code);
        }
        /// <summary>
        /// present detail of line request
        /// </summary>
        /// <param name="lineNum"></param>
        /// <returns></returns>
        LineBus IBL.presentLine(int lineNum)
        {
            return (from line in dal.getLins()
                   where line.LineNum == lineNum
                   select new LineBus(line.LineNum,GetAreas(line.Area),line.FirstStation,line.LastStation)).First();
        }
        /// <summary>
        /// add line to the list of lines in DS
        /// </summary>
        /// <param name="newLineNum"></param>
        /// <param name="area"></param>
        /// <param name="firstStop"></param>
        /// <param name="lastStop"></param>
        void IBL.AddLine(int newLineNum, string area, int firstStop, int lastStop)
        {
            if (dal.getLins().Any(x => x.LineNum == newLineNum))
            {
                throw new Exception("מספר הקו כבר קיים");
            }

            // add line and in the same time uppdate all relevant lists in data
            // base with the added information

            dal.AddLine(newLineNum,area,firstStop,lastStop);
            dal.AddAdjacentStatision(firstStop, lastStop,"0", new TimeSpan());
            dal.AddStopOfLine(firstStop, newLineNum, 1);
            dal.AddStopOfLine(lastStop, newLineNum, 2);

        }

        /// <summary>
        /// return enumrerable that used to present all actives lines
        /// in the DS
        /// </summary>
        /// <param name="run"></param>
        /// <returns></returns>

        IEnumerable<LineBus> IBL.presentAllLines()
        {
            // choose just the actives lines
            var lines = (from item in dal.getLins()
                         where item.IsActive == true
                         select (new LineBus(item.LineNum, GetAreas(item.Area), item.FirstStation, item.LastStation))).ToList();
            // from the list that we got we go throuw every line and
            // and insert to the list iof station of the line, all the matchings stations. 
            // after that sorted them by index
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
                        //calculate time and distance from begining 
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
                    item.Stops[i].DistanceFromPrivios = double.Parse(string.Format("{0:0.00}", item.Stops[i].DistanceFromBeginnig - item.Stops[i - 1].DistanceFromBeginnig)); 
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
        public IEnumerable<Bus> presentAllBus()
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
                    bus.LsaatTreastKm = item.LastTreastKm;
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
            bus.LastTreastKm = busToUpdate.LsaatTreastKm;
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
        public bool canDrive(Bus bus)
        {
            if (bus.InTreamant)
            {
                throw new Exception($"האוטובוס {bus.Id}בטיפול לא ניתן להתחיל נסיעה");
            }
            else if (bus.InRefule)
            {
                throw new Exception($"האוטובוס {bus.Id}בתידלוק לא ניתן להתחיל נסיעה");
                ;
            }
            else if (bus.InDriving)
            {
                throw new Exception($"האוטובוס {bus.Id}כבר בנסיעה לא ניתן להתחיל נסיעה");
                ;
            }
            // if all conditon alow it, sanding the bus
            else
            {
                return true;
            }
        }

        public bool canDrive(Bus bus, string kM)
        {
            if (bus.Gas - int.Parse(kM) <= 0)
            {
                throw new DataException ("there is no enough gas fo driving");
            }
            else if (((bus.LsaatTreastKm) + int.Parse(kM)) > 20000)
            {
                throw new DataException("you need take the bus to treatment, over km treatment");
            }
            else if ((CheckingDate(bus.LastTreatDate.ToString())))
            {
                throw new DataException("over a year past since the last treatment");
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

        public bool Refuell(Bus bus)
        {
            if (bus.Gas == 1200)
            {
                throw new DataException("The fuel is already full");
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

        public IEnumerable<BO.DataRealTime> getDataStop(int code, int h, int m)
        {
            return from a in dal.getAllTrips()
                   from b in dal.getLins()
                   select new BO.DataRealTime();
                    //  where 
        }
        void IBL.RemoveStop(int code)
        {
            dal.RemoveStop(code);
        }
        IEnumerable<LineBus> IBL.GetLinsInStop(int code)
        {
            return (from stop in dal.GetStopsOfLine()
                    from line in dal.getLins()
                    where stop.Id == code && stop.OfLine == line.LineNum
                    select new LineBus(line.LineNum, GetAreas(line.Area), line.FirstStation, line.LastStation) { LastStationName=dal.getStation(line.LastStation).Name }).ToList().Distinct();
        }
        List<Station> IBL.GetAdjacentStatisionBefore(int code)
        {
            var list = (from AD in dal.getAdjacentStatisions()
                        from stop1 in dal.getStations()
                        from stop2 in dal.getStations()
                        where AD.Station_2 == code && stop1.Code == AD.Station_1 && stop2.Code == AD.Station_2
                        //TODO לבטל ישות תחנות כפולות ולקחת רק תחנות
                       select new Station() {Code = AD.Station_1 , DistanceFromPrivios = AD.Distance,Name = stop1.Name , TimeFromPrivios = AD.Time }).ToList();
                    // select new AdjacentStatision(AD.Station_1,AD.Station_2,stop1.Name,stop2.Name,AD.Distance,AD.Time)).ToList();

            return list;
        }
        List<Station> IBL.GetAdjacentStatisionAfter(int code)
        {
            var list = (from AD in dal.getAdjacentStatisions()
                        from stop1 in dal.getStations()
                        from stop2 in dal.getStations()
                        where AD.Station_1 == code && stop1.Code == AD.Station_1 && stop2.Code == AD.Station_2
                        select new Station() { Code = AD.Station_2, DistanceFromPrivios = AD.Distance, Name = stop2.Name, TimeFromPrivios = AD.Time }).ToList();

          //  select new AdjacentStatision(AD.Station_1, AD.Station_2, stop1.Name, stop2.Name, AD.Distance, AD.Time)).ToList();

            return list;
        }
        public IEnumerable<Station> presentAllStation()
        {

            List<Station> list = new List<Station>();

                foreach (var item in dal.getStations())
                {
                    list.Add(new Station(item.Code, item.Name, item.Longtitude, item.Latitude));

                }


            return list;
        }
        void IBL.AddStation(string name, string code, string longtitude, string latitude)
        {

            try
            {
                dal.addStation(int.Parse(code), name, double.Parse(longtitude), double.Parse(latitude));
            }
            catch (DuplicateNameException)
            {

                throw;
            }
        }

        void IBL.updateStop(Station station , int oldNum)
        {
            if (dal.getStations().Any(x => x.Code == station.Code && oldNum != station.Code))
            {
                throw new DataException("מספר התחנה כבר קיים");
            }

            dal.EditStation(station.Code,station.Name,station.Latitude,station.Longtitude , oldNum);
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
        void IBL.ChangePass(User user, string newPass)
        {
            dal.ChangePass(user.UserName,newPass);
        }
      public  bool isUserMang(string userName, string password, bool isMang)
        {
            return dal.dalIsUser(userName, password, isMang);
        }

        bool IBL.isUser(string userName, string pass)
        {
            return dal.dalIsUser(userName, pass, false);
        }

        public void StartSimulator()
        {
            throw new NotImplementedException();
        }

       
        #endregion
    }
}


       
