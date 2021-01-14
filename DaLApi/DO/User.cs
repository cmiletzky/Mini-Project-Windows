using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
   public class User
    {
        string userName;
        string password;
        bool admin;

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public bool Admin { get => admin; set => admin = value; }


        public User()
        {

        }
        public User(string userName,string password,bool admin = false)
        {
            UserName = userName;
            Password = password;
            Admin = admin;
        }
    }
}
