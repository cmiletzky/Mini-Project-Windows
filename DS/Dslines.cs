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
      public static  List<DO.Line> lines = new List<DO.Line>();


       public static void intializeLines()
        {
            for (int i = 0; i < 10; i++)
            {
                List<int> list = initializeStops();
                lines.Add(new Line(i + 2 * i, ran.Next(1,6), list[0], list[9], list));
            }
        }

       public static List<int> initializeStops() 
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list[i]= DsStations.stations[ran.Next(0, 50)];
            }
            return list;
        }

    }
}
