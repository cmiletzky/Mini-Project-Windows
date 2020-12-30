using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    
  public  class DSstopOfLine
    {
       public static List<StopOfLine> stopOfLines = new List<DO.StopOfLine>();

        public DSstopOfLine()
        {
            stopOfLines.Add(new StopOfLine(212, 863578, 1));
            stopOfLines.Add(new StopOfLine(212, 400897, 2));
            stopOfLines.Add(new StopOfLine(212, 465033, 3));
            stopOfLines.Add(new StopOfLine(212, 232846, 4));
            stopOfLines.Add(new StopOfLine(212, 289990, 5));
            stopOfLines.Add(new StopOfLine(212, 000333, 6));
            stopOfLines.Add(new StopOfLine(212, 440000, 7));
            stopOfLines.Add(new StopOfLine(212, 110433, 8));
            stopOfLines.Add(new StopOfLine(212, 129563, 9));
            stopOfLines.Add(new StopOfLine(212, 113224, 10));
            
            stopOfLines.Add(new StopOfLine(22, 449800, 1));
            stopOfLines.Add(new StopOfLine(22, 300199, 2));
            stopOfLines.Add(new StopOfLine(22, 009999, 3));
            stopOfLines.Add(new StopOfLine(22, 232846, 4));
            stopOfLines.Add(new StopOfLine(22, 000333, 5));
            stopOfLines.Add(new StopOfLine(22, 349867, 6));
            stopOfLines.Add(new StopOfLine(22, 334442, 7));
            stopOfLines.Add(new StopOfLine(22, 289990, 8));
            stopOfLines.Add(new StopOfLine(22, 444098, 9));
            stopOfLines.Add(new StopOfLine(22, 090805, 10));
            
            stopOfLines.Add(new StopOfLine(356, 772410, 1));
            stopOfLines.Add(new StopOfLine(356, 277628, 2));
            stopOfLines.Add(new StopOfLine(356, 837027, 3));
            stopOfLines.Add(new StopOfLine(356, 334442, 4));
            stopOfLines.Add(new StopOfLine(356, 388751, 5));
            stopOfLines.Add(new StopOfLine(356, 457888, 6));
            stopOfLines.Add(new StopOfLine(356, 400897, 7));
            stopOfLines.Add(new StopOfLine(356, 009856, 8));
            stopOfLines.Add(new StopOfLine(356, 449800, 9));
            stopOfLines.Add(new StopOfLine(356, 111332, 10));
           
            stopOfLines.Add(new StopOfLine(236, 789004, 1));
            stopOfLines.Add(new StopOfLine(236, 110433, 2));
            stopOfLines.Add(new StopOfLine(236, 489276, 3));
            stopOfLines.Add(new StopOfLine(236, 300090, 4));
            stopOfLines.Add(new StopOfLine(236, 229077, 5));
            stopOfLines.Add(new StopOfLine(236, 334442, 6));
            stopOfLines.Add(new StopOfLine(236, 889209, 7));
            stopOfLines.Add(new StopOfLine(236, 300199, 8));
            stopOfLines.Add(new StopOfLine(236, 567223, 9));
            stopOfLines.Add(new StopOfLine(236, 777786, 10));
           
            stopOfLines.Add(new StopOfLine(112, 555665, 1));
            stopOfLines.Add(new StopOfLine(112, 090805, 2));
            stopOfLines.Add(new StopOfLine(112, 777786, 3));
            stopOfLines.Add(new StopOfLine(112, 113224, 4));
            stopOfLines.Add(new StopOfLine(112, 465033, 5));
            stopOfLines.Add(new StopOfLine(112, 444098, 6));
            stopOfLines.Add(new StopOfLine(112, 289990, 7));
            stopOfLines.Add(new StopOfLine(112, 489276, 8));
            stopOfLines.Add(new StopOfLine(112, 909087, 9));
            stopOfLines.Add(new StopOfLine(112, 110433, 10));
           
            stopOfLines.Add(new StopOfLine(907, 109623, 1));
            stopOfLines.Add(new StopOfLine(907, 113224, 2));
            stopOfLines.Add(new StopOfLine(907, 245559, 3));
            stopOfLines.Add(new StopOfLine(907, 440000, 4));
            stopOfLines.Add(new StopOfLine(907, 334096, 5));
            stopOfLines.Add(new StopOfLine(907, 300090, 6));
            stopOfLines.Add(new StopOfLine(907, 009999, 7));
            stopOfLines.Add(new StopOfLine(907, 567223, 8));
            stopOfLines.Add(new StopOfLine(907, 444098, 9));
            stopOfLines.Add(new StopOfLine(907, 129563, 10));
           
            stopOfLines.Add(new StopOfLine(34, 109623, 1));
            stopOfLines.Add(new StopOfLine(34, 667302, 2));
            stopOfLines.Add(new StopOfLine(34, 448990, 3));
            stopOfLines.Add(new StopOfLine(34, 277628, 4));
            stopOfLines.Add(new StopOfLine(34, 772410, 5));
            stopOfLines.Add(new StopOfLine(34, 229077, 6));
            stopOfLines.Add(new StopOfLine(34, 388751, 7));
            stopOfLines.Add(new StopOfLine(34, 113224, 8));
            stopOfLines.Add(new StopOfLine(34, 772410, 9));
            stopOfLines.Add(new StopOfLine(34, 334096, 10));
           
            stopOfLines.Add(new StopOfLine(280, 567223, 1));
            stopOfLines.Add(new StopOfLine(280, 863578, 2));
            stopOfLines.Add(new StopOfLine(280, 129563, 3));
            stopOfLines.Add(new StopOfLine(280, 909087, 4));
            stopOfLines.Add(new StopOfLine(280, 009999, 5));
            stopOfLines.Add(new StopOfLine(280, 456788, 6));
            stopOfLines.Add(new StopOfLine(280, 889209, 7));
            stopOfLines.Add(new StopOfLine(280, 300199, 8));
            stopOfLines.Add(new StopOfLine(280, 567223, 9));
            stopOfLines.Add(new StopOfLine(280, 456788, 10));
           
            stopOfLines.Add(new StopOfLine(142, 289990, 1));
            stopOfLines.Add(new StopOfLine(142, 300090, 2));
            stopOfLines.Add(new StopOfLine(142, 229077, 3));
            stopOfLines.Add(new StopOfLine(142, 110433, 4));
            stopOfLines.Add(new StopOfLine(142, 444980, 5));
            stopOfLines.Add(new StopOfLine(142, 440000, 6));
            stopOfLines.Add(new StopOfLine(142, 837027, 7));
            stopOfLines.Add(new StopOfLine(142, 234350, 8));
            stopOfLines.Add(new StopOfLine(142, 111332, 9));
            stopOfLines.Add(new StopOfLine(142, 334096, 10));
           
            stopOfLines.Add(new StopOfLine(480, 000333, 1));
            stopOfLines.Add(new StopOfLine(480, 009999, 2));
            stopOfLines.Add(new StopOfLine(480, 110433, 3));
            stopOfLines.Add(new StopOfLine(480, 109623, 4));
            stopOfLines.Add(new StopOfLine(480, 448990, 5));
            stopOfLines.Add(new StopOfLine(480, 667302, 6));
            stopOfLines.Add(new StopOfLine(480, 789004, 7));
            stopOfLines.Add(new StopOfLine(480, 400897, 8));
            stopOfLines.Add(new StopOfLine(480, 111332, 9));
            stopOfLines.Add(new StopOfLine(480, 444098, 10));
           
        }
    }
}
