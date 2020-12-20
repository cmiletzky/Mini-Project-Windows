using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaLApi;
using DS;
using DO;


namespace Dal
{
    public sealed class DalObject : IDAL
    {
        private static readonly DalObject instance = new DalObject();
        static DalObject() {
            DsBuses.intialbus();
            DsStations.initializedStation();
            Dslines.intializeLines();
        }
        private DalObject() { }
        public static DalObject Instance { get { return instance; } }

        #region Bus
        void IDAL.addBus(Bus busToAdd)
        {
            DsBuses.buslist.Add(busToAdd);
        }
        Bus IDAL.getBus(string id)
        {
            return DsBuses.buslist[DsBuses.buslist.FindIndex(x => x.Id == id)];
        }
        void IDAL.updateBus(Bus bustoUpdate)
        {
            int busID = DsBuses.buslist.FindIndex(x => x.Id == bustoUpdate.Id);
            DsBuses.buslist[busID] = bustoUpdate;

        }
        void IDAL.Delete(Bus bustoDelete)
        {
            int busID = DsBuses.buslist.FindIndex(x => x.Id == bustoDelete.Id);
            DsBuses.buslist[busID].IsActive = false;
        }

        IEnumerable<Bus> IDAL.getAllBuses()
        {
            
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
       public bool dalIsUser(string userName, string password)
        {
            DsUsers.GetUsers();
            int u = DsUsers.Users.FindIndex(x => x.UserName == userName && x.Password == password);
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

       public IEnumerable<int> getStations()
        {
            
            return DsStations.stations.Clone();
        }

        public static IEnumerable<Line> getLins()
        {
            
            return Dslines.lines.Clone();
        }

       public static string[] NameStops()
        {
            return DsStations.stationListNames;
        }
    }
}
