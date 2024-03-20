using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Login.DataModels.User
{
    public class User
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public User()
        {
            FullName = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            Salt = string.Empty;
        }
        public User(string FullName, string Username, string Password, string Salt)
        {
            this.FullName = FullName;
            this.Username = Username;
            this.Password = Password;
            this.Salt = Salt;
        }
    }
}
