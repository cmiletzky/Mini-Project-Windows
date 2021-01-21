using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    /// <summary>
    /// abstruct entity to represent details on specific
    /// 
    /// </summary>
   public class LineTrip
    {
        int id;
        int lineId;
        TimeSpan startAt;
        TimeSpan frequecy;
        TimeSpan finishAt;

        public LineTrip(int lineId, TimeSpan startAt)
        {
            this.lineId = lineId;
            this.startAt = startAt;
        }
        public int Id { get => id; set => id = value; }
        public int LineId { get => lineId; set => lineId = value; }
        public TimeSpan StartAt { get => startAt; set => startAt = value; }
        public TimeSpan Frequecy { get => frequecy; set => frequecy = value; }
        public TimeSpan FinishAt { get => finishAt; set => finishAt = value; }
    }
}
