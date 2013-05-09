using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace WineDataDomain
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public DateTime RegDate { get; set; }

        public User GetFriendList()
        {
            return null; 
        }

        
    }
}
