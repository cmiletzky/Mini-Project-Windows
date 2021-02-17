using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    

  public  class DsLineTrip
    {
        public static List<DO.LineTrip> lineTrips = new List<DO.LineTrip>();

        public DsLineTrip()
        {
            lineTrips.Add(new DO.LineTrip(212,new TimeSpan(08,00,00),10, new TimeSpan(20, 00, 00)));
            lineTrips.Add(new DO.LineTrip(22,new TimeSpan(08,00,00),5,new TimeSpan(20,00,00)));
            lineTrips.Add(new DO.LineTrip(356,new TimeSpan(08,00,00),8,new TimeSpan(20,00,00)));
            lineTrips.Add(new DO.LineTrip(236,new TimeSpan(08,00,00),15,new TimeSpan(20,00,00)));
            lineTrips.Add(new DO.LineTrip(112,new TimeSpan(08,00,00),20,new TimeSpan(20,00,00)));
            lineTrips.Add(new DO.LineTrip(907,new TimeSpan(08,00,00),3,new TimeSpan(20,00,00)));
            lineTrips.Add(new DO.LineTrip(34,new TimeSpan(08,00,00),5,new TimeSpan(20,00,00)));
            lineTrips.Add(new DO.LineTrip(280,new TimeSpan(08,00,00),10,new TimeSpan(20,00,00)));
            lineTrips.Add(new DO.LineTrip(142,new TimeSpan(08,00,00),4,new TimeSpan(20,00,00)));
            lineTrips.Add(new DO.LineTrip(480,new TimeSpan(08,00,00),2,new TimeSpan(20,00,00)));
        }
    }
}
