using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    enum Areas                                                  // definde enum for area value
    {
        General = 1, North, South, Center, Jerusalem
    }
    class Line
    {
        int id;
        int code;
        Areas area;

        public int Id { get => id; set => id = value; }
        public int Code { get => code; set => code = value; }
    }
}
