using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
     public class Auth
    {
       public static User user;
        public Auth(string userName, string password,bool isMang)
        {
 
            BusinessLayer businessLayer = new BusinessLayer();
            if (businessLayer.isUserMang(userName, password, true))
            {
                user = new User(userName, password ,isMang);
            }
            else
            {
                user = new User(userName, password, false);

            }
        }

        
    }
}
