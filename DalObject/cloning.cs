using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using DS;

namespace Dal
{
    static class cloning
    {
        internal static IEnumerable<Bus> Clone(this IEnumerable<Bus> original)
        {
            List<Bus> target = new List<Bus>();
            foreach (var item in original)
            {
                target.Add(new Bus(item.Id, item.StartDate));
            }
            return (IEnumerable<Bus>)target;
        }
    }
}
