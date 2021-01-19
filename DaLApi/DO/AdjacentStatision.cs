using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    /// <summary>
    /// entity to represent peer of two station
    /// </summary>
   public class AdjacentStatision
    {
        int station_1;
        int station_2;
        double distance;
        TimeSpan time;

        public AdjacentStatision(int stop1,int stop2, double distance, TimeSpan time)
        {
            this.station_1 = stop1;
            this.station_2 = stop2;
            this.distance = double.Parse(string.Format("{0:0.00}", distance)); ;
            this.time = time;
        }

        public int Station_1 { get => station_1; set => station_1 = value; }
        public int Station_2 { get => station_2; set => station_2 = value; }
        public double Distance { get => distance; set => distance = value; }
        public TimeSpan Time { get => time; set => time = value; }
    }
}
