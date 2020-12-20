using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class Station
    {

        int code;
        string name;
        int longtitude;
        int latitude;

        public int Latitude { get => latitude; set => latitude = value; }
        public int Longtitude { get => longtitude; set => longtitude = value; }
        public string Name { get => name; set => name = value; }
        public int Code { get => code; set => code = value; }

        public Station(int code, string name, int longtitude, int latitude)
        {
            this.code = code;
            this.name = name;
            this.longtitude = longtitude;
            this.latitude = latitude;
        }
    }
}
