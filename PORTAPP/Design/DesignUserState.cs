using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PORTAPP.Design
{
    public class DesignUserState : UserSystem.IUserState
    {

        public UserSystem.UserState getUserState()
        {
            return new UserSystem.UserState { IsLoggedIn = true, LoggedInUserName = "DesignViewUser" };
        }
    }
}
