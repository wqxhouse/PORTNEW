using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceDataLib
{
    public partial class User
    {
        public WineDataDomain.User ToDomainUser()
        {
            WineDataDomain.User u = new WineDataDomain.User();
            u.UserName = this.nickname;
            u.PassWord = this.password;
            u.ID = this.user_id;
            u.Email = this.email;
            u.RegDate = this.reg_date;
            return u;
            
        }

        public void UpdateFromDomainUser(WineDataDomain.User user)
        {

            this.nickname = user.UserName;
            this.email = user.Email;
            this.password = user.PassWord;
        }
    }
}
