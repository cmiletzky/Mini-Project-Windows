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

        void IDAL.RemoveStopLine(StopOfLine stop)
        {
            int index = DSstopOfLine.stopOfLines.FindIndex(x => x.Id == stop.Id && x.OfLine == stop.OfLine);
            DSstopOfLine.stopOfLines.RemoveAt(index);
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
