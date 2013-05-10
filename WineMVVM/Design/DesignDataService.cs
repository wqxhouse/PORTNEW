using System;

using System.Collections.Generic;

namespace WineMVVM.Background.Design
{
    public class DesignDataService : WineDataDomain.IUserRepository
    {

        public void GetAllUserData(Action<IEnumerable<WineDataDomain.User>, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void GetFriendData(Action<IEnumerable<WineDataDomain.FriendList>, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(IEnumerable<WineDataDomain.User> user, Action<string, Exception> callback)
        {
            throw new NotImplementedException();
        }
    }
}