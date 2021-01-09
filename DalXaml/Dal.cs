using DaLApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXaml
{
    class Dal : IDAL
    {
        void IDAL.activeBus(string busNum)
        {
            throw new NotImplementedException();
        }

        void IDAL.AddAdjacentStatision(int stop1, int stop2, string distnase, TimeSpan time)
        {
            throw new NotImplementedException();
        }

        void IDAL.addBus(string busNam, DateTime? startDate)
        {
            throw new NotImplementedException();
        }

        void IDAL.AddLine(int newLineNum, string area, int firstStop, int lastStop)
        {
            throw new NotImplementedException();
        }

        void IDAL.addStation(int code, string name, double longtitude, double latitude)
        {
            throw new NotImplementedException();
        }

        void IDAL.AddStopOfLine(int stopNum, int lineNum, int after)
        {
            throw new NotImplementedException();
        }

        void IDAL.addUser(User user)
        {
            throw new NotImplementedException();
        }

        int IDAL.BusAlreadyExists(string busNam)
        {
            throw new NotImplementedException();
        }

        void IDAL.ChangePass(string userName, string newPass)
        {
            throw new NotImplementedException();
        }

        bool IDAL.CheckAdjacentStatision(int stop1, int stop2)
        {
            throw new NotImplementedException();
        }

        bool IDAL.dalIsUser(string userName, string password, bool isMang)
        {
            throw new NotImplementedException();
        }

        void IDAL.DeleteBus(string BusId)
        {
            throw new NotImplementedException();
        }

        void IDAL.deliteUser(string userName)
        {
            throw new NotImplementedException();
        }

        void IDAL.EditAdjacentStatision(int stop1, int stop2, double dis, TimeSpan time)
        {
            throw new NotImplementedException();
        }

        void IDAL.EditLine(int oldLineNum, int lineNum, string area)
        {
            throw new NotImplementedException();
        }

        void IDAL.EditStation(int code, string name, double latitude, double longtitude, int oldNum)
        {
            throw new NotImplementedException();
        }

        void IDAL.editUser(User user)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AdjacentStatision> IDAL.getAdjacentStatisions()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Bus> IDAL.getAllBuses()
        {
            throw new NotImplementedException();
        }

        Bus IDAL.getBus(string id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<LineBus> IDAL.getLins()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Station> IDAL.getStations()
        {
            throw new NotImplementedException();
        }

        IEnumerable<StopOfLine> IDAL.GetStopsOfLine()
        {
            throw new NotImplementedException();
        }

        List<User> IDAL.getUsers()
        {
            throw new NotImplementedException();
        }

        void IDAL.InitializeData()
        {
            throw new NotImplementedException();
        }

        Bus IDAL.isBus(Bus x)
        {
            throw new NotImplementedException();
        }

        void IDAL.RemoveLine(int lineNum)
        {
            throw new NotImplementedException();
        }

        void IDAL.RemoveStop(int code)
        {
            throw new NotImplementedException();
        }

        void IDAL.RemoveStopFromLine(StopOfLine stop)
        {
            throw new NotImplementedException();
        }

        void IDAL.RemoveStopLine(int code)
        {
            throw new NotImplementedException();
        }

        void IDAL.updateBus(Bus bustoUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
