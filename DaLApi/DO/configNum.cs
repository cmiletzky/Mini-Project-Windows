﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaLApi.DO
{
    public class configNum
    {
        static int LineId = 0;
        public configNum()
        {

        }

        public static int LineId { get => LineId; set => LineId = value; }
    }
}
