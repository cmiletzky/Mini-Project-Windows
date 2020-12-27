using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    
    class DSstopOfLine
    {
       public static List<StopOfLine> stopOfLines = new List<DO.StopOfLine>();

        public DSstopOfLine()
        {
            stopOfLines.Add(new StopOfLine(212, 863578, 0));
            stopOfLines.Add(new StopOfLine(212, 400897, 1));
            stopOfLines.Add(new StopOfLine(212, 465033, 2));
            stopOfLines.Add(new StopOfLine(212, 009856, 3));
            stopOfLines.Add(new StopOfLine(212, 289990, 4));
            stopOfLines.Add(new StopOfLine(212, 000333, 5));
            stopOfLines.Add(new StopOfLine(212, 440000, 6));
            stopOfLines.Add(new StopOfLine(212, 110433, 7));
            stopOfLines.Add(new StopOfLine(212, 129563, 8));
            stopOfLines.Add(new StopOfLine(212, 113224, 9));
            
            stopOfLines.Add(new StopOfLine(22, 449800, 0));
            stopOfLines.Add(new StopOfLine(22, 300199, 1));
            stopOfLines.Add(new StopOfLine(22, 009999, 2));
            stopOfLines.Add(new StopOfLine(22, 232846, 3));
            stopOfLines.Add(new StopOfLine(22, 000333, 4));
            stopOfLines.Add(new StopOfLine(22, 349867, 5));
            stopOfLines.Add(new StopOfLine(22, 334442, 6));
            stopOfLines.Add(new StopOfLine(22, 289990, 7));
            stopOfLines.Add(new StopOfLine(22, 444098, 8));
            stopOfLines.Add(new StopOfLine(22, 090805, 9));
            
            stopOfLines.Add(new StopOfLine(356, 772410, 0));
            stopOfLines.Add(new StopOfLine(356, 277628, 1));
            stopOfLines.Add(new StopOfLine(356, 837027, 2));
            stopOfLines.Add(new StopOfLine(356, 334442, 3));
            stopOfLines.Add(new StopOfLine(356, 388751, 4));
            stopOfLines.Add(new StopOfLine(356, 457888, 5));
            stopOfLines.Add(new StopOfLine(356, 400897, 6));
            stopOfLines.Add(new StopOfLine(356, 009856, 7));
            stopOfLines.Add(new StopOfLine(356, 449800, 8));
            stopOfLines.Add(new StopOfLine(356, 111332, 9));
           
            stopOfLines.Add(new StopOfLine(236, 789004, 0));
            stopOfLines.Add(new StopOfLine(236, 110433, 1));
            stopOfLines.Add(new StopOfLine(236, 489276, 2));
            stopOfLines.Add(new StopOfLine(236, 300090, 3));
            stopOfLines.Add(new StopOfLine(236, 229077, 4));
            stopOfLines.Add(new StopOfLine(236, 334442, 5));
            stopOfLines.Add(new StopOfLine(236, 889209, 6));
            stopOfLines.Add(new StopOfLine(236, 300199, 7));
            stopOfLines.Add(new StopOfLine(236, 567223, 8));
            stopOfLines.Add(new StopOfLine(236, 777786, 9));
           
            stopOfLines.Add(new StopOfLine(112, 555665, 0));
            stopOfLines.Add(new StopOfLine(112, 090805, 1));
            stopOfLines.Add(new StopOfLine(112, 777786, 2));
            stopOfLines.Add(new StopOfLine(112, 113224, 3));
            stopOfLines.Add(new StopOfLine(112, 465033, 4));
            stopOfLines.Add(new StopOfLine(112, 444098, 5));
            stopOfLines.Add(new StopOfLine(112, 289990, 6));
            stopOfLines.Add(new StopOfLine(112, 489276, 7));
            stopOfLines.Add(new StopOfLine(112, 909087, 8));
            stopOfLines.Add(new StopOfLine(112, 110433, 9));
           
            stopOfLines.Add(new StopOfLine(907, 109623, 0));
            stopOfLines.Add(new StopOfLine(907, 113224, 1));
            stopOfLines.Add(new StopOfLine(907, 245559, 2));
            stopOfLines.Add(new StopOfLine(907, 440000, 3));
            stopOfLines.Add(new StopOfLine(907, 334096, 4));
            stopOfLines.Add(new StopOfLine(907, 300090, 5));
            stopOfLines.Add(new StopOfLine(907, 009999, 6));
            stopOfLines.Add(new StopOfLine(907, 567223, 7));
            stopOfLines.Add(new StopOfLine(907, 444098, 8));
            stopOfLines.Add(new StopOfLine(907, 129563, 9));
           
            stopOfLines.Add(new StopOfLine(34, 109623, 0));
            stopOfLines.Add(new StopOfLine(34, 109623, 1));
            stopOfLines.Add(new StopOfLine(34, 109623, 2));
            stopOfLines.Add(new StopOfLine(34, 109623, 3));
            stopOfLines.Add(new StopOfLine(34, 109623, 4));
            stopOfLines.Add(new StopOfLine(34, 109623, 5));
            stopOfLines.Add(new StopOfLine(34, 109623, 6));
            stopOfLines.Add(new StopOfLine(34, 109623, 7));
            stopOfLines.Add(new StopOfLine(34, 109623, 8));
            stopOfLines.Add(new StopOfLine(34, 334096, 9));
           
            stopOfLines.Add(new StopOfLine(280, 567223, 0));
            stopOfLines.Add(new StopOfLine(280, 567223, 1));
            stopOfLines.Add(new StopOfLine(280, 567223, 2));
            stopOfLines.Add(new StopOfLine(280, 567223, 3));
            stopOfLines.Add(new StopOfLine(280, 567223, 4));
            stopOfLines.Add(new StopOfLine(280, 567223, 5));
            stopOfLines.Add(new StopOfLine(280, 567223, 6));
            stopOfLines.Add(new StopOfLine(280, 567223, 7));
            stopOfLines.Add(new StopOfLine(280, 567223, 8));
            stopOfLines.Add(new StopOfLine(280, 456788, 9));
           
            stopOfLines.Add(new StopOfLine(142, 289990, 0));
            stopOfLines.Add(new StopOfLine(142, 289990, 1));
            stopOfLines.Add(new StopOfLine(142, 289990, 2));
            stopOfLines.Add(new StopOfLine(142, 289990, 3));
            stopOfLines.Add(new StopOfLine(142, 289990, 4));
            stopOfLines.Add(new StopOfLine(142, 289990, 5));
            stopOfLines.Add(new StopOfLine(142, 289990, 6));
            stopOfLines.Add(new StopOfLine(142, 289990, 7));
            stopOfLines.Add(new StopOfLine(142, 289990, 8));
            stopOfLines.Add(new StopOfLine(142, 334096, 9));
           
            stopOfLines.Add(new StopOfLine(480, 000333, 0));
            stopOfLines.Add(new StopOfLine(480, 000333, 1));
            stopOfLines.Add(new StopOfLine(480, 000333, 2));
            stopOfLines.Add(new StopOfLine(480, 000333, 3));
            stopOfLines.Add(new StopOfLine(480, 000333, 4));
            stopOfLines.Add(new StopOfLine(480, 000333, 5));
            stopOfLines.Add(new StopOfLine(480, 000333, 6));
            stopOfLines.Add(new StopOfLine(480, 000333, 7));
            stopOfLines.Add(new StopOfLine(480, 000333, 8));
            stopOfLines.Add(new StopOfLine(480, 444098, 9));
           
        }
    }
}
