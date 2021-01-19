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
        General = 1, North = 2, South = 3, Center = 4, Jerusalem = 5
    }

    /// <summary>
    /// entity to represent bus lin ein spesific area
    /// </summary>
    public class LineBus
    {
        int id;
        bool isActive = true;
        int lineNum;
       
        Areas area;
        int firstStation;
        int lastStation;





        public int Id { get => id; set => id = value; }
        public int LineNum { get => lineNum; set => lineNum = value; }
        public int FirstStation { get => firstStation; set => firstStation = value; }
        public int LastStation { get => lastStation; set => lastStation = value; }
        public Areas Area { get => area; set => area = value; }
        public bool IsActive { get => isActive; set => isActive = value; }

        public LineBus(int lineNum, Areas area, int firstStation, int lastStation)
        {
            this.id = configNum.LineId++;
            this.lineNum = lineNum;
            this.firstStation = firstStation;
            this.lastStation = lastStation;
            this.area = area;
            
        }
    }
}
