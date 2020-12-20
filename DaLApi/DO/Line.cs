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
        General = 1, North, South, Center, Jerusalem
    }
    public class Line
    {
        int id;
        int lineNum;
        Areas area;
        int firstStation;
        int lastStation;
        List<StopOfLine> stationList = new List<StopOfLine>();



        public int Id { get => id; set => id = value; }
        public int LineNum { get => lineNum; set => lineNum = value; }
        public int FirstStation { get => firstStation; set => firstStation = value; }
        public int LastStation { get => lastStation; set => lastStation = value; }
        internal Areas Area { get => area; set => area = value; }
        public List<StopOfLine> StationList { get => stationList; set => stationList = value; }

        public Line( int lineNum, Areas area, int firstStation, int lastStation, List<StopOfLine> stationList)
        {
            this.id = configNum.LineId++ ;
            this.lineNum = lineNum;
            this.area = area;
            this.firstStation = firstStation;
            this.lastStation = lastStation;
            this.stationList = stationList;
        }
    }
}
