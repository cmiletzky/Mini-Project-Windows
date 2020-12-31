using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaLApi;
using DS;
using DO;
using System.Data;

namespace Dal
{
    public sealed class DalObject : IDAL
    {
        private static readonly DalObject instance = new DalObject();
        static DalObject() {
         
        }
        private DalObject() {

           


        }
        public static DalObject Instance { get { return instance; } }
        void IDAL.InitializeData()
        {
            new DsUsers();
            new DsBuses();
            new DsStations();
            new DSstopOfLine();
            new Dslines();
            new DsAdjacentStatision();
        }

        #region Bus

       public int BusAlreadyExists(string busNam)
        {
            foreach (var item in DsBuses.buslist)
            {
               string a= item.Id.Replace("-", "");
                if (a==busNam)
                {
                    if (item.IsActive==false)
                    {
                        return 2;
                    }
                    return 0;
                }
            }
            return 1;
        }
        void IDAL.addBus(string busNam, DateTime? startDate)
        {
            DsBuses.buslist.Add(new Bus(busNam,startDate));
        }
        void IDAL.activeBus(string busNum)
        {
            DsBuses.buslist[DsBuses.buslist.FindIndex(x => x.Id == busNum)].IsActive = true;
        }
        Bus IDAL.getBus(string id)
        {
            return DsBuses.buslist[DsBuses.buslist.FindIndex(x => x.Id == id)];
        }
        void IDAL.updateBus(Bus bustoUpdate)
        {
        //    int busID = DsBuses.buslist.FindIndex(x => x.Id == bustoUpdate.Id);
            DsBuses.buslist[0] = bustoUpdate;

        }
        void IDAL.DeleteBus(string busId)
        {
            int busID = DsBuses.buslist.FindIndex(x => x.Id == busId);
            DsBuses.buslist[busID].IsActive = false;
        }

        IEnumerable<Bus> IDAL.getAllBuses(bool run)
        {
            if (run==true)
            {
                DsBuses.intialbus();
            }
            
            return DsBuses.buslist.Clone();
        }

        Bus IDAL.isBus(Bus x)
        {
            if (x is Bus)
                return x;
            return null;

        }
        #endregion

        #region User
       public bool dalIsUser(string userName, string password, bool isMang)
        {
            DsUsers.GetUsers();
            int u = DsUsers.Users.FindIndex(x => x.UserName == userName && x.Password == password && x.Admin==isMang);
            if (u == -1)
            {
                return false;
            }
            return true;
        }
        public List<User> getUsers()
        {
            return DsUsers.GetUsers();
        }

        public void addUser(User user)
        {
            DsUsers.Users.Add(user);
        }

        public void editUser(User user)
        {
            DsUsers.Users[DsUsers.Users.FindIndex(x => x.UserName == user.UserName)] = user;
        }

        public void deliteUser(string userName)
        {
            DsUsers.Users.RemoveAt(DsUsers.Users.FindIndex(x => x.UserName == userName));
        }
        #endregion

        void IDAL.AddLine(int newLineNum, string area, int firstStop, int lastStop)
        {
            Dslines.lines.Add(new LineBus(newLineNum, GetAreas(area), firstStop, lastStop));
        }

        void IDAL.EditAdjacentStatision(int stop1, int stop2, double dis, TimeSpan time) 
        {

            foreach (var item in DsAdjacentStatision.adjacentStatisions)
            {
                if (item.Station_1 == stop1 && item.Station_2 == stop2)
                {
                    item.Time = time;
                    item.Distance = dis;
                }
            }

        }
        void IDAL.AddAdjacentStatision(int stop1, int stop2, string distnase, TimeSpan time)
        {
            DsAdjacentStatision.adjacentStatisions.Add(new AdjacentStatision(stop1, stop2, double.Parse(distnase), time));
        }
        IEnumerable<AdjacentStatision> IDAL.getAdjacentStatisions(/*Predicate<AdjacentStatision> predicate*/)
        {
            var d = (from item9 in DsAdjacentStatision.adjacentStatisions
                 // where predicate(item9)
                 select item9).ToList();
            return d;
        }

        bool IDAL.CheckAdjacentStatision(int stop1, int stop2)
        {
            return DsAdjacentStatision.adjacentStatisions.Any(x => x.Station_1 == stop1 && x.Station_2 == stop2);
        }
        void IDAL.AddStopOfLine(int stopNum, int lineNum, int after)
        {
            //מקדם את האינדקס של שאר התחנות
            foreach (var item in DSstopOfLine.stopOfLines)
            {
                if (item.OfLine == lineNum && item.StatIndex>=after)
                {
                    item.StatIndex++;
                }
            }
            DS.DSstopOfLine.stopOfLines.Add(new StopOfLine(lineNum, stopNum, after));
        }
        void IDAL.RemoveStopLine(StopOfLine stop)
        {
            int index = DSstopOfLine.stopOfLines.FindIndex(x => x.Id == stop.Id && x.OfLine == stop.OfLine);
            DSstopOfLine.stopOfLines.RemoveAt(index);

            foreach (var item in DSstopOfLine.stopOfLines)
            {
                if (item.OfLine == stop.OfLine && item.StatIndex>stop.StatIndex)
                {
                    item.StatIndex--;
                }
            }
        }
        IEnumerable<StopOfLine> IDAL.GetStopsOfLine()
        {
            
            return DSstopOfLine.stopOfLines;
        }
       public IEnumerable<Station> getStations(bool run)
        {
            
            return DsStations.stations.Clone();
        }

        public  IEnumerable<LineBus> getLins(bool run)
        {
            
            return Dslines.lines.Clone();
        }

        void IDAL.EditLine(int oldLineNum, int lineNum, string area)
        {
            foreach (var item in Dslines.lines)
            {
                if (item.LineNum== oldLineNum)
                {
                    item.LineNum = lineNum;
                    item.Area = GetAreas(area);
                }
            }

            foreach (var item in DSstopOfLine.stopOfLines)
            {
                if (item.OfLine == oldLineNum)
                {
                    item.OfLine = lineNum;
                }
            }
        }

        Areas GetAreas(string a)
        {
            switch (a)
            {
                case "General":
                    return Areas.General;
                case "North":
                    return Areas.North;
                case "South":
                    return Areas.South;
                case "Center":
                    return Areas.Center;
                case "Jerusalem":
                    return Areas.Jerusalem;
                default:
                    return Areas.General;
            }
        }
        void IDAL.RemoveLine(int lineNum)
        {
            int lineID = Dslines.lines.FindIndex(x => x.LineNum == lineNum);
            Dslines.lines[lineID].IsActive = false;
        }

        public void addStation(int code, string name, int longtitude, int latitude)
        {
            Station newStation;
            try
            {
                Station check = DsStations.stations.Find(x => x.Code == code);
                if (check!=null && check.IsActive == true)
                {
                    throw new DuplicateNameException();
                }
                else if (check.IsActive==false)
                {
                    check.IsActive = true;
                    check.Latitude = latitude;
                    check.Longtitude = longtitude;
                    check.Name = name;
                }
                else
                {
                    newStation = new Station(code, name, longtitude, latitude);
                    DsStations.stations.Add(newStation);
                }


            }
            catch (DuplicateNameException)
            {

                throw;
            }
        }
    }
}
