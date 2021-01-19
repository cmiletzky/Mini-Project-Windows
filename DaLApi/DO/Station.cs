using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    /// <summary>
    /// entity to represent details of a bus station
    /// </summary>
    public class Station
    {

        int code;
        string name;
        double longtitude;
        double latitude;
        bool isActive = true;

        public double Latitude { get => latitude; set => latitude = value; }
        public double Longtitude { get => longtitude; set => longtitude = value; }
        public string Name { get => name; set => name = value; }
        public int Code { get => code; set => code = value; }
        public bool IsActive { get => isActive; set => isActive = value; }

        public Station(int code, string name, double longtitude, double latitude)
        {
            this.code = code;
            this.name = name;
            this.longtitude = longtitude;
            this.latitude = latitude;
        }
    }
}
