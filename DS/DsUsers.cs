using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
   public class DsUsers
    {
      public static  List<DO.User> Users = new List<DO.User>();
        static public List<DO.User> GetUsers()
        {
            Users.Add(new DO.User("a","1",true));
            Users.Add(new DO.User("b","2"));
            Users.Add(new DO.User("c","3"));
            Users.Add(new DO.User("d","4"));
            return Users;
        }
    }
}
