using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaLApi.DO;
using DO;

namespace DO
{
    public enum Areas                                                  // definde enum for area value
    {
        General = 1, North = 2, South = 3, Center = 4, Jerusalem = 5
    }
    public class LineBus
    {
        int id;
        int lineNum;
        Areas area;
        int firstStation;
        int lastStation;
       List<int> stationList = new List<int>();



        public int Id { get => id; set => id = value; }
        public int LineNum { get => lineNum; set => lineNum = value; }
        public int FirstStation { get => firstStation; set => firstStation = value; }
        public int LastStation { get => lastStation; set => lastStation = value; }
        internal Areas Area { get => area; set => area = value; }
        public List<int> StationList { get => stationList; set => stationList = value; }

        public LineBus(int lineNum, int area, int firstStation, int lastStation, List<int> stationList)
        {
            this.id = configNum.LineId++;
            this.lineNum = lineNum;
            this.firstStation = firstStation;
            this.lastStation = lastStation;
            this.stationList = stationList;
            switch (area)
            {
                case 1:
                    this.area = Areas.Center;
                    break;
                case 2:
                    this.area = Areas.General;
                    break;
                case 3:
                    this.area = Areas.Jerusalem;
                    break;
                case 4:
                    this.area = Areas.North;
                    break;
                case 5:
                    this.area = Areas.South;
                    break;
                default:
                    this.area = Areas.General;
                    break;
            }
        }
    }
}
