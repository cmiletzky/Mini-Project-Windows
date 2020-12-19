using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using DaLApi;

namespace BL
{
    class BusinessLayer : IBL
    {
        IDAL dal = DalFactory.GetDal();
        public IEnumerable<BO.Bus> presentAllBus()
        {

            List<BO.Bus> allBuses = new List<BO.Bus>();// = dal.getAllBuses() ;//.Where(x => x == x) ; 
            foreach (var item in dal.getAllBuses())
            {
                allBuses.Add(new BO.Bus(item.Id,item.StartDate));
            }
            return allBuses;
        }
    }
}
