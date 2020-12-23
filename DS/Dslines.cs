using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaLApi.DO;
using DO;

namespace DS
{
   public class Dslines
    {
       public static Random ran = new Random(DateTime.Now.Millisecond);
      public static  List<DO.LineBus> lines = new List<DO.LineBus>();


       public static void intializeLines()
        {
            for (int i = 0; i < 10; i++)
            {
                List<int> list = initializeStops();
                lines.Add(new LineBus(ran.Next(1,300), ran.Next(1,6), list[0], list[9], list));
            }
        }

       public static List<int> initializeStops() 
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                int stop = DsStations.stations[ran.Next(0, 50)].Code;
                while(list.FindIndex(x=>x==stop)!=-1)
                 {
                     stop = DsStations.stations[ran.Next(0, 50)].Code;
                }
                list.Add(stop);

            }
            return list;
        }

    }
}
