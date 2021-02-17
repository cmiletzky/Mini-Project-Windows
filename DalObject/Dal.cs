using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaLApi;
using DS;
using DO;
using System.Data;
using System.Xml.Linq;

namespace Dal
{
    public sealed class DalObject : IDAL
    {
        private static readonly DalObject instance = new DalObject();
        static DalObject(){
        
        
        }
        private DalObject(){
        
        
        }
        public static DalObject Instance { get { return instance; } }
        /// <summary>
        /// initials all the data base in DS   
        /// </summary>
        void IDAL.InitializeData()
        {
            new DsUsers();
            new DsBuses();
            new DsStations();
            new DSstopOfLine();
            new Dslines();
            new DsAdjacentStatision();
            new DsLineTrip();
        }

        #region Bus

        /// <summary>
        /// check wether the bus already exsist in the data source
        /// </summary>
        /// <param name="busNam"></param>
        /// <returns></returns>
       public int BusAlreadyExists(string busNam)
        {
            foreach (var item in DsBuses.buslist)
            {
                //ocnvertto rghit format for the checking
                string a = item.Id.Replace("-", "");
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
        /// <summary>
        /// adding new bus to DS
        /// </summary>
        /// <param name="busNam"></param>
        /// <param name="startDate"></param>
        void IDAL.addBus(string busNam, DateTime? startDate)
        {
            DsBuses.buslist.Add(new Bus(busNam,startDate));
        }
        /// <summary>
        /// change the status of specific bus to be "ACTIVE"
        /// </summary>
        /// <param name="busNum"></param>
        void IDAL.activeBus(string busNum)
        {
            DsBuses.buslist[DsBuses.buslist.FindIndex(x => x.Id == busNum)].IsActive = true;
        }
        /// <summary>
        /// return requested bus acording to ID as identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Bus IDAL.getBus(string id)
        {
            return DsBuses.buslist[DsBuses.buslist.FindIndex(x => x.Id == id)];
        }
        /// <summary>
        /// updating bus in DS
        /// </summary>
        /// <param name="bustoUpdate"></param>
        void IDAL.updateBus(Bus bustoUpdate)
        {
            DsBuses.buslist[DsBuses.buslist.FindIndex(x=>x.Id==bustoUpdate.Id)] = bustoUpdate;

        }
        /// <summary>
        /// deleting bus, meaning: change status to be "IsActive = false"
        /// </summary>
        /// <param name="busId"></param>
        void IDAL.DeleteBus(string busId)
        {
            int busID = DsBuses.buslist.FindIndex(x => x.Id == busId);
            DsBuses.buslist[busID].IsActive = false;
        }
        /// <summary>
        /// return the collection of all buses actives in the company
        /// </summary>
        /// <returns></returns>
        IEnumerable<Bus> IDAL.getAllBuses()
        {
            return DsBuses.buslist.Clone();
        }

        #endregion

        #region User
        /// <summary>
        /// get userName and password and boolian if the user is manager
        /// and acording to the recordes give the right access
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="isMang"></param>
        /// <returns></returns>
        public bool dalIsUser(string userName, string password, bool isMang)
        {

            // verfy wether the user inded exsist in the compani's recordes 
            DsUsers.GetUsers();
            int u = DsUsers.Users.FindIndex(x => x.UserName == userName && x.Password == password && x.Admin==isMang);
            if (u == -1)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// return lisyt ao all users
        /// </summary>
        /// <returns></returns>
        public List<User> getUsers()
        {
            return DsUsers.GetUsers();
        }
        /// <summary>
        /// adding new user
        /// </summary>
        /// <param name="user"></param>
        public void addUser(User user)
        {
            DsUsers.Users.Add(user);
        }
        /// <summary>
        /// edit specific user
        /// </summary>
        /// <param name="user"></param>
        public void editUser(User user)
        {
            DsUsers.Users[DsUsers.Users.FindIndex(x => x.UserName == user.UserName)] = user;
        }
        /// <summary>
        /// unactivate specific user
        /// </summary>
        /// <param name="userName"></param>
        public void deliteUser(string userName)
        {
            DsUsers.Users.RemoveAt(DsUsers.Users.FindIndex(x => x.UserName == userName));
        }
        #endregion
        /// <summary>
        /// adding new line to DS
        /// </summary>
        /// <param name="newLineNum"></param>
        /// <param name="area"></param>
        /// <param name="firstStop"></param>
        /// <param name="lastStop"></param>
        void IDAL.AddLine(int newLineNum, string area, int firstStop, int lastStop)
        {
            Dslines.lines.Add(new LineBus(newLineNum, GetAreas(area), firstStop, lastStop));
        }
        /// <summary>
        /// edit peer of adjacence station
        /// </summary>
        /// <param name="stop1"></param>
        /// <param name="stop2"></param>
        /// <param name="dis"></param>
        /// <param name="time"></param>
        void IDAL.EditAdjacentStatision(int stop1, int stop2, double dis, TimeSpan time) 
        {
            // searchig for requested item
            foreach (var item in DsAdjacentStatision.adjacentStatisions)
            {
                if (item.Station_1 == stop1 && item.Station_2 == stop2)
                {
                    item.Time = time;
                    item.Distance = dis;
                }
            }

        }
        /// <summary>
        /// adding a new peer of two adjacence stations
        /// </summary>
        /// <param name="stop1"></param>
        /// <param name="stop2"></param>
        /// <param name="distnase"></param>
        /// <param name="time"></param>
        void IDAL.AddAdjacentStatision(int stop1, int stop2, string distnase, TimeSpan time)
        {
            DsAdjacentStatision.adjacentStatisions.Add(new AdjacentStatision(stop1, stop2, double.Parse(distnase), time));
        }
        /// <summary>
        ///  return an inemerble
        /// </summary>
        /// <returns></returns>
        IEnumerable<AdjacentStatision> IDAL.getAdjacentStatisions()
        {

            return DsAdjacentStatision.adjacentStatisions.Clone();

        }
        /// <summary>
        /// check wether two of statins are adjacence
        /// </summary>
        /// <param name="stop1"></param>
        /// <param name="stop2"></param>
        /// <returns>true  or false</returns>
        bool IDAL.CheckAdjacentStatision(int stop1, int stop2)
        {
            return DsAdjacentStatision.adjacentStatisions.Any(x => x.Station_1 == stop1 && x.Station_2 == stop2);
        }
        void IDAL.AddStopOfLine(int stopNum, int lineNum, int after)
        {
            //forwardinf the idex of all rest station after that who just added 
            foreach (var item in DSstopOfLine.stopOfLines)
            {
                if (item.OfLine == lineNum && item.StatIndex>=after)
                {
                    item.StatIndex++;
                }
            }
            DS.DSstopOfLine.stopOfLines.Add(new StopOfLine(lineNum, stopNum, after));
        }
        /// <summary>
        /// remoove 'station of line' from DS
        /// </summary>
        /// <param name="code"></param>
        void IDAL.RemoveStopLine(int code)
        {
            for (int i = 0;i < DSstopOfLine.stopOfLines.Count();i++)
            {
                if (DSstopOfLine.stopOfLines[i].Id == code)
                {
                    DSstopOfLine.stopOfLines.RemoveAt(i);

                }
            }
        }
        /// <summary>
        /// remoove specific station from its line, identifing by station code
        /// </summary>
        /// <param name="stop"></param>
        void IDAL.RemoveStopFromLine(StopOfLine stop)
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
        /// <summary>
        /// return the collection of all 'stop of lines'
        /// </summary>
        /// <returns></returns>
        IEnumerable<StopOfLine> IDAL.GetStopsOfLine()
        {
            return DSstopOfLine.stopOfLines.Clone();
        }
        /// <summary>
        /// return list of all station exsisting in DS
        /// </summary>
        /// <returns></returns>
       public IEnumerable<Station> getStations()
        {
            
            return DsStations.stations.Clone();
        }
        /// <summary>
        /// return all lines exsisting in DS
        /// </summary>
        /// <returns></returns>
        public  IEnumerable<LineBus> getLins()
        {
            
            return Dslines.lines.Clone();
        }
        /// <summary>
        /// update sprcific line in DS
        /// </summary>
        /// <param name="oldLineNum"></param>
        /// <param name="lineNum"></param>
        /// <param name="area"></param>
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
            //in paralel updating the DS of stopOfLines
            foreach (var item in DSstopOfLine.stopOfLines)
            {
                if (item.OfLine == oldLineNum)
                {
                    item.OfLine = lineNum;
                }
            }
        }
        /// <summary>
        /// asisting func to get the requested area by string
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
    public static Areas GetAreas(string a)
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Station IDAL.getStation(int id)
        {
            return DS.DsStations.stations.Find(x => x.Code == id);
        }
        void IDAL.RemoveLine(int lineNum)
        {
            int lineID = Dslines.lines.FindIndex(x => x.LineNum == lineNum);
            Dslines.lines[lineID].IsActive = false;

            for (int i = 0; i < DSstopOfLine.stopOfLines.Count(); i++)
            {
                if (DSstopOfLine.stopOfLines[i].OfLine == lineNum)
                {
                    DSstopOfLine.stopOfLines.RemoveAt(i);
                }
            }
        }


        void IDAL.RemoveStop(int code)
        {
            DsStations.stations.RemoveAt(DsStations.stations.FindIndex(x => x.Code == code));
            try
            {
                DSstopOfLine.stopOfLines.RemoveAt(DSstopOfLine.stopOfLines.FindIndex(x => x.Id == code));
                DsAdjacentStatision.adjacentStatisions.RemoveAt(DsAdjacentStatision.adjacentStatisions.FindIndex(x => x.Station_2 == code || x.Station_2 == code));
            }
            catch (Exception){}
        }

        void IDAL.EditStation(int code, string name, double latitude, double longtitude , int oldNum)
        {
            DsStations.stations[DsStations.stations.FindIndex(x => x.Code == oldNum)] =
                 new Station(code, name, longtitude, latitude);
        }

        public void addStation(int code, string name, double longtitude, double latitude)
        {
             
            try
            {
                Station check = DsStations.stations.Find(x => x.Code == code);
                if (check!=null && check.IsActive == true)
                {
                    throw new DuplicateNameException();
                }
                else if (check!=null&&check.IsActive==false)
                {
                    check.IsActive = true;
                    check.Latitude = latitude;
                    check.Longtitude = longtitude;
                    check.Name = name;
                }
                else
                {
                    Station newStation = new Station(code, name, longtitude, latitude);
                    DsStations.stations.Add(newStation);
                }


            }
            catch (DuplicateNameException)
            {

                throw;
            }
        }

        void IDAL.ChangePass(string userName, string newPass)
        {
            DsUsers.Users[DsUsers.Users.FindIndex(x => x.UserName == userName)].Password = newPass;
        }

        public IEnumerable<LineTrip> getAllTrips()
        {
            return DS.DsLineTrip.lineTrips;
        }
    }
}
