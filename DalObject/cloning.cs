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
       
        //internal static IEnumerable<Bus> Clone(this IEnumerable<Bus> original)
        //{
        //    List<Bus> target = new List<Bus>();
        //    foreach (var item in original)
        //    {
        //        string a = item.Id.Replace("-","");
        //        target.Add(item);
        //    }
        //    return (IEnumerable<Bus>)target;
        //} 
        
        internal static IEnumerable<Station> Clone(this IEnumerable<Station> original)
        {
            List<Station> target = new List<Station>();
            foreach (var item in original)
            {
                target.Add(item);
            }
            return target;
        } 
        internal static List<LineBus> Clone(this List<LineBus> original)
        {
            List<LineBus> target = new List<LineBus>();
            foreach (var item in original)
            {
                target.Add(item);
            }
            return target;
        }
    }
}
