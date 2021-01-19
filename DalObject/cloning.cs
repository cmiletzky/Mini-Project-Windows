using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DO;
using DS;

namespace Dal
{
    /// <summary>
    /// class for holding all the cloning function
    /// 
    /// </summary>
    static class cloning
    {
        //internal static T Clone<T>(this T original) where T : new()
        //{
        //    T copyToObject = new T();
        //    //T copyToObject = (T)Activator.CreateInstance(typeof(T));

        //    foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
        //        propertyInfo.SetValue(copyToObject, propertyInfo.GetValue(original, null), null);

        //    return copyToObject;
        //}


        internal static IEnumerable<Bus> Clone(this IEnumerable<Bus> original)
        {
            List<Bus> target = new List<Bus>();
            foreach (var item in original)
            {
                string a = item.Id.Replace("-", "");
                target.Add(item);
            }
            return (IEnumerable<Bus>)target;
        }

        internal static IEnumerable<Station> Clone(this IEnumerable<Station> original)
        {
            List<Station> target = new List<Station>();
            foreach (var item in original)
            {
                target.Add(item);
            }
            return target;
        }  
        
        internal static IEnumerable<StopOfLine> Clone(this IEnumerable<StopOfLine> original)
        {
            List<StopOfLine> target = new List<StopOfLine>();
            foreach (var item in original)
            {
                target.Add(item);
            }
            return target;
        }    
        
        internal static IEnumerable<AdjacentStatision> Clone(this IEnumerable<AdjacentStatision> original)
        {
            List<AdjacentStatision> target = new List<AdjacentStatision>();
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
