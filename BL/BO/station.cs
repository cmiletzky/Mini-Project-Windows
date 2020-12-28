using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Station
    {

        int code;
        string name;
        int longtitude;
        int latitude;
        private int distanceFromPrivios;            // distance from the privios bus stop
        private int timeFromPrivios;

        public int Latitude { get => latitude; set => latitude = value; }
        public int Longtitude { get => longtitude; set => longtitude = value; }
        public string Name { get => name; set => name = value; }
        public int Code { get => code; set => code = value; }
        public int DistanceFromPrivios { get => distanceFromPrivios; set => distanceFromPrivios = value; }
        public int TimeFromPrivios { get => timeFromPrivios; set => timeFromPrivios = value; }

        public Station(int code, string name, int longtitude, int latitude)
        {
            this.code = code;
            this.name = name;
            this.longtitude = longtitude;
            this.latitude = latitude;
        }
    }
}
