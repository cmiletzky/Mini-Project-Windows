using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaLApi.DO;
using DO;

namespace BO
{
    public enum Areas // definde enum for area value
    {
        General = 1, North = 2, South = 3, Center = 4, Jerusalem = 5
    }
    public class LineBus
    {
        int id;
        int lineNum;
        List<Station> stops = new List<Station>();
      

        Areas area;
        int firstStation;
        int lastStation;
        string lastStationName;



        public int Id { get => id; set => id = value; }
        public int LineNum { get => lineNum; set => lineNum = value; }
        public int FirstStation { get => firstStation; set => firstStation = value; }
        public int LastStation { get => lastStation; set => lastStation = value; }
        public Areas Area { get => area; set => area = value; }
        public List<Station> Stops { get => stops; set => stops = value; }
        public string LastStationName { get => lastStationName; set => lastStationName = value; }

        public LineBus(int lineNum, Areas area, int firstStation, int lastStation)
        {
            this.id = configNum.LineId++;
            this.lineNum = lineNum;
            this.firstStation = firstStation;
            this.lastStation = lastStation;
            this.area = area;
           

            //switch (area)
            //{
            //    case 1:
            //        this.area = Areas.Center;
            //        break;
            //    case 2:
            //        this.area = Areas.General;
            //        break;
            //    case 3:
            //        this.area = Areas.Jerusalem;
            //        break;
            //    case 4:
            //        this.area = Areas.North;
            //        break;
            //    case 5:
            //        this.area = Areas.South;
            //        break;
            //    default:
            //        this.area = Areas.General;
            //        break;
            //}
        }
    }
}
