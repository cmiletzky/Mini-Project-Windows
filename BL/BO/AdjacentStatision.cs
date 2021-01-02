using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
  public  class AdjacentStatision
    {
        int stationNum1;
        int stationNum2;
        string stationName1;
        string stationName2;
        double distance;
        TimeSpan time;

        public AdjacentStatision(int stop1, int stop2, string name1 , string name2, double distance, TimeSpan time)
        {
            this.stationNum1 = stop1;
            this.stationNum2 = stop2;
            stationName1 = name1;
            stationName2 = name2;
            this.distance = distance;
            this.time = time;
        }

        public int StationNum1 { get => stationNum1; set => stationNum1 = value; }
        public int StationNum2 { get => stationNum2; set => stationNum2 = value; }
        public double Distance { get => distance; set => distance = value; }
        public TimeSpan Time { get => time; set => time = value; }
        public string StationName1 { get => stationName1; set => stationName1 = value; }
        public string StationName2 { get => stationName2; set => stationName2 = value; }
    }
}
