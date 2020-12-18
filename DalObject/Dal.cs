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
        static DalObject() { }
        private DalObject() { }
        public static DalObject Instance { get { return instance; } }

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
            DataSource.intialbus();
            return DataSource.buslist.Clone();
        }

        Bus IDAL.isBus(Bus x)
        {
            if (x is Bus)
                return x;
            return null;

        }
    }
}
