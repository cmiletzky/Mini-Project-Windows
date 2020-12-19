using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    class LineStatision
    {
        int lineId;
        int station;
        int lineStationIndex;
        int prevStation;
        int nextStation;

        public int LineId { get => lineId; set => lineId = value; }
        public int Station { get => station; set => station = value; }
        public int LineStationIndex { get => lineStationIndex; set => lineStationIndex = value; }
        public int PrevStation { get => prevStation; set => prevStation = value; }
        public int NextStation { get => nextStation; set => nextStation = value; }
    }
}
