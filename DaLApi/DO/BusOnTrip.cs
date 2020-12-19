using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    class BusOnTrip
    {
        int id;
        int lisenceNum;
        int lineId;
        TimeSpan planedTakeOff;
        TimeSpan actualTakeOff;
        int prevStation;
        TimeSpan prevStationAt;
        TimeSpan nextStationAt;


        public int Id { get => id; set => id = value; }
        public int LisenceNum { get => lisenceNum; set => lisenceNum = value; }
        public TimeSpan PlanedTakeOff { get => planedTakeOff; set => planedTakeOff = value; }
        public TimeSpan ActualTakeOff { get => actualTakeOff; set => actualTakeOff = value; }
        public int PrevStation { get => prevStation; set => prevStation = value; }
        public TimeSpan PrevStasionAt { get => prevStationAt; set => prevStationAt = value; }
        public TimeSpan NextStationAt { get => nextStationAt; set => nextStationAt = value; }
    }
}
