using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class StopOfLine
    {
        int ofLine;
        int id;
        int statIndex;

        public int OfLine { get => ofLine; set => ofLine = value; }
        public int Id { get => id; set => id = value; }
        public int StatIndex { get => statIndex; set => statIndex = value; }

        public StopOfLine(int ofLine ,int id, int statIndex)
        {
            this.ofLine= ofLine;
            this.id= id;
            this.statIndex= statIndex;
        }
    }
}
