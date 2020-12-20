using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    class Auth
    {
       public User user;
        public Auth(string userName, string password)
        {
            BusinessLayer businessLayer = new BusinessLayer();
            if (businessLayer.isUser(userName, password))
            {
                user = new User(userName, password);
            }
        }

        
    }
}
