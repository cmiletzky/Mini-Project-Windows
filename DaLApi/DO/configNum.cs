using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaLApi.DO
{
    public class configNum
    {
        static int lineId = 0;
        public static int LineId { get => lineId; set => lineId = value; }
    }
}
