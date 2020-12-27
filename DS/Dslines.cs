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
        public static List<DO.LineBus> lines = new List<DO.LineBus>();
        public Dslines()
        {
            lines.Add(new LineBus(212, Areas.Jerusalem, 863578, 113224));
            lines.Add(new LineBus(22, Areas.South, 449800, 090805));
            lines.Add(new LineBus(356, Areas.General, 772410, 111332));
            lines.Add(new LineBus(236, Areas.Center, 789004, 777786));
            lines.Add(new LineBus(112, Areas.Jerusalem, 555665, 110433));
            lines.Add(new LineBus(907, Areas.Jerusalem, 109623, 129563));
            lines.Add(new LineBus(34, Areas.North, 109623, 334096));
            lines.Add(new LineBus(280, Areas.South, 567223, 456788));
            lines.Add(new LineBus(142, Areas.Center, 289990, 334096));
            lines.Add(new LineBus(480, Areas.General, 000333, 444098));
        }

    }
}
