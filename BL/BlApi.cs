using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BL;
using BL.BO;

namespace BlApi
{
    public interface IBL
    {
        void InitializeData();
        bool CheckAdjacentStatision(int stop1 , int stop2);
        IEnumerable<BO.Station> presentStopsOfLine(int lineNum);
        IEnumerable<BO.Station> presentStopsLine();
        void RemoveLine(BO.LineBus lineBus);
        void AddStopLine(int stopNum, int lineNum, int after);
        void CheckStopIsInLine(int stopNum, int lineNum);
        void RemoveStopFromLine(int lineNum, int stopCode);
        void RemoveBus(Bus busToRemove);
        void updateBus(Bus busToUpdate);
        void AddBus(string busNam, DateTime? startDate);
        IEnumerable<Bus> presentAllBus(bool run);
        IEnumerable<BO.Station> presentAllStation(bool run);
        void AddLine(int newLineNum, string area,int firstStop,int lastStop);
        IEnumerable<BO.LineBus> presentAllLines(bool run);
        void AddStation(string name, string code, string longtitude, string latitude);
        // void RemoveStation(BO.Station stationToRemove);
        bool canDrive(Bus bus, ref string mes);
        bool canDrive(Bus bus, ref string mes, string kM);
        bool Refuell(Bus bus, ref string mes);

        bool isUserMang(string userName, string password, bool isMang);
        void AddAdjacentStatision(int stop1, int stop2, string distnase, TimeSpan time);
        void EditAdjacentStatision(int stop1, int stop2, double dis, TimeSpan time);
        void EditLine(int oldLineNum,int lineNum, string area);
    }
    public static class BlFactory
    {
        public static IBL GetBl()
        {
            return new BusinessLayer();
        }

        public static IBL GetBl(int blType)
        {
            switch (blType)
            {
                case 1:
                    return new BusinessLayer();
                case 2:
                    return new BL.BusinessLayer(); // new BL.BlImp2()
                default:
                    throw new ArgumentException("Bad BL number");
            }
        }

    }
}
