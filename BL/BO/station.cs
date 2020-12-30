﻿using System;
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
        int indexInLine;
        int longtitude;
        int latitude;
        Station priviosStop;
        private double distanceFromPrivios = 0;            // distance from the privios bus stop
        private double distanceFromBeginnig = 0;            // distance from the privios bus stop
        private TimeSpan timeFromPrivios;
        private TimeSpan timeFromBeginnig;

        bool isNotFirst = true;

        public int Latitude { get => latitude; set => latitude = value; }
        public int Longtitude { get => longtitude; set => longtitude = value; }
        public string Name { get => name; set => name = value; }
        public int Code { get => code; set => code = value; }
        public double DistanceFromPrivios { get => distanceFromPrivios; set => distanceFromPrivios = value; }
        public TimeSpan TimeFromPrivios { get => timeFromPrivios; set => timeFromPrivios = value; }
        public Station PriviosStop { get => priviosStop; set => priviosStop = value; }
        public int IndexInLine { get => indexInLine; set => indexInLine = value; }
        public TimeSpan TimeFromBeginnig { get => timeFromBeginnig; set => timeFromBeginnig = value; }
        public double DistanceFromBeginnig { get => distanceFromBeginnig; set => distanceFromBeginnig = value; }
        public bool IsNotFirst { get => isNotFirst; set => isNotFirst = value; }

        public Station(int code, string name, int longtitude, int latitude,int index)
        {
            this.code = code;
            this.name = name;
            this.longtitude = longtitude;
            this.latitude = latitude;
            this.indexInLine = index;
           
        }    public Station(int code, string name, int longtitude, int latitude)
        {
            this.code = code;
            this.name = name;
            this.longtitude = longtitude;
            this.latitude = latitude;
          
           
        }
    }
}
