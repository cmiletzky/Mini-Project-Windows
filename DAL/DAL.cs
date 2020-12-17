using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaLApi;
using DO;
using DS;



namespace Dal
{
    public sealed class DAL : IDAL
    {
        private static readonly DAL instance = new DAL();
        static DAL() { }
        private DAL() { }
        public static DAL Instance { get { return instance; } }

        void IDAL.addBus(Bus busToAdd)
        {
            DataSource.buslist.Add(busToAdd);
        }
        Bus IDAL.getBus(string id)
        {
            return DataSource.buslist[DataSource.buslist.FindIndex(x => x.Id == id)];
        }
        void IDAL.updateBus(Bus bustoUpdate)
        {
            int busID = DataSource.buslist.FindIndex(x => x.Id == bustoUpdate.Id);
            DataSource.buslist[busID] = bustoUpdate;

        }
        void IDAL.Delete(Bus bustoDelete)
        {
            int busID = DataSource.buslist.FindIndex(x => x.Id == bustoDelete.Id);
            DataSource.buslist[busID].IsActive = false;
        }

        IEnumerable<Bus> IDAL.getAllBuses()
        {
            return DataSource.buslist;
        }

        Bus IDAL.isBus(Bus x)
        {
            if (x is Bus)
                return x;
            return null;

        }
    }
}
