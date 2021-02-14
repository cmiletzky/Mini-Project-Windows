using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BL;
using BL.BO;
using BO;

namespace BlApi
{
    public interface IBL
    {
        void InitializeData();
        bool CheckAdjacentStatision(int stop1 , int stop2);
        List<BO.Station> presentStopsOfLine(int lineNum);
        IEnumerable<BO.Station> presentStopsLine();
        void RemoveLine(BO.LineBus lineBus);
        void AddStopLine(int stopNum, int lineNum, int after);
        void CheckStopIsInLine(int stopNum, int lineNum);
        void RemoveStopFromLine(int lineNum, int stopCode);
        void RemoveBus(Bus busToRemove);
        void updateBus(Bus busToUpdate);
        void AddBus(string busNam, DateTime? startDate);
        IEnumerable<Bus> presentAllBus();
        IEnumerable<BO.Station> presentAllStation();
        void AddLine(int newLineNum, string area,int firstStop,int lastStop);
        void updateStop(Station station, int oldNum);
        void ChangePass(User user, string newPass);
        IEnumerable<BO.LineBus> presentAllLines();
        void AddStation(string name, string code, string longtitude, string latitude);
        // void RemoveStation(BO.Station stationToRemove);
        bool canDrive(Bus bus);
        bool canDrive(Bus bus, string kM);
        bool Refuell(Bus bus);

       bool  isUserMang(string userName, string password, bool isMang);
        void StartSimulator();
        void AddAdjacentStatision(int stop1, int stop2, string distnase, TimeSpan time);
        void EditAdjacentStatision(int stop1, int stop2, double dis, TimeSpan time);
        void EditLine(int oldLineNum,int lineNum, string area);
        List<BO.Station> GetAdjacentStatisionBefore(int code);
        List<BO.Station> GetAdjacentStatisionAfter(int code);
        bool isUser(string userName, string pass);
        IEnumerable<BO.LineBus> GetLinsInStop(int code);
        BO.LineBus presentLine(int lineNum);
        void RemoveStopLine(int code);
        void RemoveStop(int code);
    }
    public static class BlFactory
    {
        public static IBL GetBl()
        {
            return new BusinessLayer();
        }

    }
}
