using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    class DsAdjacentStatision
    {
        List<AdjacentStatision> adjacentStatisions = new List<AdjacentStatision>();

        public DsAdjacentStatision()
        {
            adjacentStatisions.Add(new AdjacentStatision(863578, 400897, 4.0, TimeSpan.FromMinutes(3)));
            adjacentStatisions.Add(new AdjacentStatision(400897, 465033, 4.1, TimeSpan.FromMinutes(3.1)));
            adjacentStatisions.Add(new AdjacentStatision(465033, 232846, 4.2, TimeSpan.FromMinutes(3.2)));
            adjacentStatisions.Add(new AdjacentStatision(232846, 289990, 4.3, TimeSpan.FromMinutes(3.3)));
            adjacentStatisions.Add(new AdjacentStatision(289990, 000333, 4.4, TimeSpan.FromMinutes(3.4)));
            adjacentStatisions.Add(new AdjacentStatision(000333, 440000, 4.5, TimeSpan.FromMinutes(3.5)));
            adjacentStatisions.Add(new AdjacentStatision(440000, 110433, 4.6, TimeSpan.FromMinutes(3.6)));
            adjacentStatisions.Add(new AdjacentStatision(110433, 129563, 4.7, TimeSpan.FromMinutes(3.7)));
            adjacentStatisions.Add(new AdjacentStatision(129563, 113224, 4.8, TimeSpan.FromMinutes(3.8)));

            adjacentStatisions.Add(new AdjacentStatision(449800, 300199, 4.0, TimeSpan.FromMinutes(3)));
            adjacentStatisions.Add(new AdjacentStatision(300199, 009999, 4.1, TimeSpan.FromMinutes(3.1)));
            adjacentStatisions.Add(new AdjacentStatision(009999, 232846, 4.2, TimeSpan.FromMinutes(3.2)));
            adjacentStatisions.Add(new AdjacentStatision(232846, 000333, 4.3, TimeSpan.FromMinutes(3.3)));
            adjacentStatisions.Add(new AdjacentStatision(000333, 349867, 4.4, TimeSpan.FromMinutes(3.4)));
            adjacentStatisions.Add(new AdjacentStatision(349867, 334442, 4.5, TimeSpan.FromMinutes(3.5)));
            adjacentStatisions.Add(new AdjacentStatision(334442, 289990, 4.6, TimeSpan.FromMinutes(3.6)));
            adjacentStatisions.Add(new AdjacentStatision(289990, 444098, 4.7, TimeSpan.FromMinutes(3.7)));
            adjacentStatisions.Add(new AdjacentStatision(444098, 090805, 4.8, TimeSpan.FromMinutes(3.8)));

            adjacentStatisions.Add(new AdjacentStatision(772410, 277628, 4.0, TimeSpan.FromMinutes(3)));
            adjacentStatisions.Add(new AdjacentStatision(277628, 837027, 4.1, TimeSpan.FromMinutes(3.1)));
            adjacentStatisions.Add(new AdjacentStatision(837027, 334442, 4.2, TimeSpan.FromMinutes(3.2)));
            adjacentStatisions.Add(new AdjacentStatision(334442, 388751, 4.3, TimeSpan.FromMinutes(3.3)));
            adjacentStatisions.Add(new AdjacentStatision(388751, 457888, 4.4, TimeSpan.FromMinutes(3.4)));
            adjacentStatisions.Add(new AdjacentStatision(457888, 400897, 4.5, TimeSpan.FromMinutes(3.5)));
            adjacentStatisions.Add(new AdjacentStatision(400897, 009856, 4.6, TimeSpan.FromMinutes(3.6)));
            adjacentStatisions.Add(new AdjacentStatision(009856, 449800, 4.7, TimeSpan.FromMinutes(3.7)));
            adjacentStatisions.Add(new AdjacentStatision(449800, 111332, 4.8, TimeSpan.FromMinutes(3.8)));

            adjacentStatisions.Add(new AdjacentStatision(789004, 110433, 4.0, TimeSpan.FromMinutes(3)));
            adjacentStatisions.Add(new AdjacentStatision(110433, 489276, 4.1, TimeSpan.FromMinutes(3.1)));
            adjacentStatisions.Add(new AdjacentStatision(489276, 300090, 4.2, TimeSpan.FromMinutes(3.2)));
            adjacentStatisions.Add(new AdjacentStatision(300090, 229077, 4.3, TimeSpan.FromMinutes(3.3)));
            adjacentStatisions.Add(new AdjacentStatision(229077, 334442, 4.4, TimeSpan.FromMinutes(3.4)));
            adjacentStatisions.Add(new AdjacentStatision(334442, 889209, 4.5, TimeSpan.FromMinutes(3.5)));
            adjacentStatisions.Add(new AdjacentStatision(889209, 300199, 4.6, TimeSpan.FromMinutes(3.6)));
            adjacentStatisions.Add(new AdjacentStatision(300199, 567223, 4.7, TimeSpan.FromMinutes(3.7)));
            adjacentStatisions.Add(new AdjacentStatision(567223, 777786, 4.8, TimeSpan.FromMinutes(3.8)));

            adjacentStatisions.Add(new AdjacentStatision(555665, 090805, 4.0, TimeSpan.FromMinutes(3)));
            adjacentStatisions.Add(new AdjacentStatision(090805, 777786, 4.1, TimeSpan.FromMinutes(3.1)));
            adjacentStatisions.Add(new AdjacentStatision(777786, 113224, 4.2, TimeSpan.FromMinutes(3.2)));
            adjacentStatisions.Add(new AdjacentStatision(113224, 465033, 4.3, TimeSpan.FromMinutes(3.3)));
            adjacentStatisions.Add(new AdjacentStatision(465033, 444098, 4.4, TimeSpan.FromMinutes(3.4)));
            adjacentStatisions.Add(new AdjacentStatision(444098, 289990, 4.5, TimeSpan.FromMinutes(3.5)));
            adjacentStatisions.Add(new AdjacentStatision(289990, 489276, 4.6, TimeSpan.FromMinutes(3.6)));
            adjacentStatisions.Add(new AdjacentStatision(489276, 909087, 4.7, TimeSpan.FromMinutes(3.7)));
            adjacentStatisions.Add(new AdjacentStatision(909087, 110433, 4.8, TimeSpan.FromMinutes(3.8)));

            adjacentStatisions.Add(new AdjacentStatision(109623, 113224, 4.0, TimeSpan.FromMinutes(3)));
            adjacentStatisions.Add(new AdjacentStatision(113224, 245559, 4.1, TimeSpan.FromMinutes(3.1)));
            adjacentStatisions.Add(new AdjacentStatision(245559, 440000, 4.2, TimeSpan.FromMinutes(3.2)));
            adjacentStatisions.Add(new AdjacentStatision(440000, 334096, 4.3, TimeSpan.FromMinutes(3.3)));
            adjacentStatisions.Add(new AdjacentStatision(334096, 300090, 4.4, TimeSpan.FromMinutes(3.4)));
            adjacentStatisions.Add(new AdjacentStatision(300090, 009999, 4.5, TimeSpan.FromMinutes(3.5)));
            adjacentStatisions.Add(new AdjacentStatision(009999, 567223, 4.6, TimeSpan.FromMinutes(3.6)));
            adjacentStatisions.Add(new AdjacentStatision(567223, 444098, 4.7, TimeSpan.FromMinutes(3.7)));
            adjacentStatisions.Add(new AdjacentStatision(444098, 129563, 4.8, TimeSpan.FromMinutes(3.8)));

            adjacentStatisions.Add(new AdjacentStatision(109623, 667302, 4.0, TimeSpan.FromMinutes(3)));
            adjacentStatisions.Add(new AdjacentStatision(667302, 448990, 4.1, TimeSpan.FromMinutes(3.1)));
            adjacentStatisions.Add(new AdjacentStatision(448990, 277628, 4.2, TimeSpan.FromMinutes(3.2)));
            adjacentStatisions.Add(new AdjacentStatision(277628, 772410, 4.3, TimeSpan.FromMinutes(3.3)));
            adjacentStatisions.Add(new AdjacentStatision(772410, 229077, 4.4, TimeSpan.FromMinutes(3.4)));
            adjacentStatisions.Add(new AdjacentStatision(229077, 388751, 4.5, TimeSpan.FromMinutes(3.5)));
            adjacentStatisions.Add(new AdjacentStatision(388751, 113224, 4.6, TimeSpan.FromMinutes(3.6)));
            adjacentStatisions.Add(new AdjacentStatision(113224, 772410, 4.7, TimeSpan.FromMinutes(3.7)));
            adjacentStatisions.Add(new AdjacentStatision(772410, 334096, 4.8, TimeSpan.FromMinutes(3.8)));

            adjacentStatisions.Add(new AdjacentStatision(567223, 863578, 4.0, TimeSpan.FromMinutes(3)));
            adjacentStatisions.Add(new AdjacentStatision(863578, 129563, 4.1, TimeSpan.FromMinutes(3.1)));
            adjacentStatisions.Add(new AdjacentStatision(129563, 456788, 4.2, TimeSpan.FromMinutes(3.2)));
            adjacentStatisions.Add(new AdjacentStatision(456788, 009999, 4.3, TimeSpan.FromMinutes(3.3)));
            adjacentStatisions.Add(new AdjacentStatision(009999, 456788, 4.4, TimeSpan.FromMinutes(3.4)));
            adjacentStatisions.Add(new AdjacentStatision(456788, 889209, 4.5, TimeSpan.FromMinutes(3.5)));
            adjacentStatisions.Add(new AdjacentStatision(889209, 300199, 4.6, TimeSpan.FromMinutes(3.6)));
            adjacentStatisions.Add(new AdjacentStatision(300199, 567223, 4.7, TimeSpan.FromMinutes(3.7)));
            adjacentStatisions.Add(new AdjacentStatision(567223, 456788, 4.8, TimeSpan.FromMinutes(3.8)));

            adjacentStatisions.Add(new AdjacentStatision(289990, 300090, 4.0, TimeSpan.FromMinutes(3)));
            adjacentStatisions.Add(new AdjacentStatision(300090, 229077, 4.1, TimeSpan.FromMinutes(3.1)));
            adjacentStatisions.Add(new AdjacentStatision(229077, 110433, 4.2, TimeSpan.FromMinutes(3.2)));
            adjacentStatisions.Add(new AdjacentStatision(110433, 444980, 4.3, TimeSpan.FromMinutes(3.3)));
            adjacentStatisions.Add(new AdjacentStatision(444980, 440000, 4.4, TimeSpan.FromMinutes(3.4)));
            adjacentStatisions.Add(new AdjacentStatision(440000, 837027, 4.5, TimeSpan.FromMinutes(3.5)));
            adjacentStatisions.Add(new AdjacentStatision(837027, 234350, 4.6, TimeSpan.FromMinutes(3.6)));
            adjacentStatisions.Add(new AdjacentStatision(234350, 111332, 4.7, TimeSpan.FromMinutes(3.7)));
            adjacentStatisions.Add(new AdjacentStatision(111332, 334096, 4.8, TimeSpan.FromMinutes(3.8)));

            adjacentStatisions.Add(new AdjacentStatision(000333, 009999, 4.0, TimeSpan.FromMinutes(3)));
            adjacentStatisions.Add(new AdjacentStatision(009999, 110433, 4.1, TimeSpan.FromMinutes(3.1)));
            adjacentStatisions.Add(new AdjacentStatision(110433, 109623, 4.2, TimeSpan.FromMinutes(3.2)));
            adjacentStatisions.Add(new AdjacentStatision(109623, 448990, 4.3, TimeSpan.FromMinutes(3.3)));
            adjacentStatisions.Add(new AdjacentStatision(448990, 667302, 4.4, TimeSpan.FromMinutes(3.4)));
            adjacentStatisions.Add(new AdjacentStatision(667302, 789004, 4.5, TimeSpan.FromMinutes(3.5)));
            adjacentStatisions.Add(new AdjacentStatision(789004, 400897, 4.6, TimeSpan.FromMinutes(3.6)));
            adjacentStatisions.Add(new AdjacentStatision(400897, 111332, 4.7, TimeSpan.FromMinutes(3.7)));
            adjacentStatisions.Add(new AdjacentStatision(111332, 444098, 4.8, TimeSpan.FromMinutes(3.8)));
        }
    }
}
