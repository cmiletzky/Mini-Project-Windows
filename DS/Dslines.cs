using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaLApi.DO;
using DO;

namespace DS
{
    class Dslines
    {
        Random ran = new Random(DateTime.Now.Millisecond);
        List<DO.Line> lines = new List<DO.Line>();


        void intializeLines()
        {
            
            for (int i = 0; i < 10; i++)
            {
                List<StopOfLine> list = initializeStops(i + 2 * i);
                lines.Add(new Line(i + 2 * i, 1, list[0].Id, list[9].Id, list));
            }
        }

        List<StopOfLine> initializeStops(int j) 
        {
            List<StopOfLine> list = new List<StopOfLine>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new StopOfLine(j, DsStations.stations[ran.Next(0, 50)].Code, i));
            }
            return list;
        }

    }
}
