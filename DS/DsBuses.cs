using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DS
{
    /// <summary>
    /// intialize and store all the Vehicles in the company
    /// </summary>
    public class DsBuses
    {
        public static List<Bus> buslist = new List<Bus>();// create the list to hold the buss in company
        private static Random gen = new Random();
        static public Random r = new Random(DateTime.Now.Millisecond);
        public DsBuses()
        {
            intialbus();
        }
      static  DateTime RandomDay()
        {

            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

     static   public void intialbus()
        {
            for (int i = 0; i < 20; i++)
            {
                
                buslist.Add(new Bus(r.Next(1000000, 99999999).ToString(),RandomDay()));
                buslist[i].Km = r.Next(20000, 40000);
                buslist[i].LastTreastKm = r.Next(0, 10000);
                buslist[i].Gas = 1200;
                buslist[i].LastTreatDate = new DateTime(2020, 10, 10);

            }
            buslist[0].LastTreatDate = new DateTime(2019, 10, 10);
            buslist[0].InDriving = true;
            buslist[1].LastTreastKm = 19990;
            buslist[2].Gas = 50;


        }
    }
}
