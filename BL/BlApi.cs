﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BL;

namespace BlApi
{
    public interface IBL
    {
        void AddBus(string busNam, DateTime? startDate);
        IEnumerable<BO.Bus> presentAllBus(bool run);
        IEnumerable<BO.Station> presentAllStation();
        IEnumerable<BO.Line> presentAllLines();
        bool canDrive(BO.Bus bus, ref string mes);
        bool canDrive(BO.Bus bus, ref string mes, string kM);
        bool Refuell(BO.Bus bus, ref string mes);

        bool isUserMang(string userName, string password, bool isMang);
    }
    public static class BlFactory
    {
        public static IBL GetBl()
        {
            return new BusinessLayer();
        }

        public static IBL GetBl(int blType)
        {
            switch (blType)
            {
                case 1:
                    return new BusinessLayer();
                case 2:
                    return new BL.BusinessLayer(); // new BL.BlImp2()
                default:
                    throw new ArgumentException("Bad BL number");
            }
        }

    }
}
