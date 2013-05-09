﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WineDataDomain
{
    public interface IUserRepository
    {
        void GetAllUserData(Action<IEnumerable<User>, Exception> callback);
        void GetFriendData(Action<IEnumerable<FriendList>, Exception> callback);
        void UpdateUser(IEnumerable<User> user, Action<String, Exception> callback);
    }
}