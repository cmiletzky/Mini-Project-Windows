using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
   public class DataRealTime
    {
        int lineNum;
        string lastStop;
        TimeSpan time;

        public int LineNum { get => lineNum; set => lineNum = value; }
        public string LastStop { get => lastStop; set => lastStop = value; }
        public TimeSpan Time { get => time; set => time = value; }
    }
}
