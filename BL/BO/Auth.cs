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
            if (checkUser(userName,password))
            {
                user = new User(userName, password);
            }
        }

        public bool checkUser(string userName, string password)
        {
            return BL.BusinessLayer.isUser(userName,password);
        }
    }
}
