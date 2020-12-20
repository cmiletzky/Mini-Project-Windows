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


        public int Id { get => id; set => id = value; }
        public int LineNum { get => lineNum; set => lineNum = value; }
        public int FirstStation { get => firstStation; set => firstStation = value; }
        public int LastStation { get => lastStation; set => lastStation = value; }
        internal Areas Area { get => area; set => area = value; }

        public Line(int id, int lineNum, Areas area, int firstStation, int lastStation)
        {
            id = configNum.LineId++ ;
            lineNum = lineNum;
            area = area;
            firstStation = firstStation;
            lastStation = lastStation;
        }
    }
}
