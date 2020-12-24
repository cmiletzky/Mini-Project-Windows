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
         
        }
        private DalObject() {
         
           
           
        }
        public static DalObject Instance { get { return instance; } }

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

       public IEnumerable<Station> getStations()
        {
            DsStations.initializedStation();
            return DsStations.stations.Clone();
        }

        public  IEnumerable<LineBus> getLins()
        {
            Dslines.intializeLines();
            return Dslines.lines.Clone();
        }

      
    }
}
