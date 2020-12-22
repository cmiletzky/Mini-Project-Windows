﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaLApi.DO;
using DO;

namespace BO
{
    public enum Areas                                                  // definde enum for area value
    {
        General = 1, North = 2, South = 3, Center = 4, Jerusalem = 5
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

        public Line(int lineNum, int area, int firstStation, int lastStation, List<StopOfLine> stationList)
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