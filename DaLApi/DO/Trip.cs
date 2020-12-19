using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    class Trip
    {
        int id;
        string username;
        int lineId;
        int inStation;
        TimeSpan inAt;
        int outStation;
        TimeSpan outAt;

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public int LineId { get => lineId; set => lineId = value; }
        public int InStation { get => inStation; set => inStation = value; }
        public TimeSpan InAt { get => inAt; set => inAt = value; }
        public int OutStation { get => outStation; set => outStation = value; }
        public TimeSpan OutAt { get => outAt; set => outAt = value; }
    }
}
