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
                string a = item.Id.Replace("-","");
                allBuses.Add(new BO.Bus(a,item.StartDate));
            }
            return allBuses;
        }
    }
}
