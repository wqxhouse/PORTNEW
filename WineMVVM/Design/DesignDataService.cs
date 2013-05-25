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


        public void IsExistedUser(string username, Action<bool, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void IsExistedUser(string username, string password, Action<bool, Exception> callback)
        {
            throw new NotImplementedException();
        }


        public void CreateNewUser(WineDataDomain.User user, Action<bool, Exception> callback)
        {
            throw new NotImplementedException();
        }
    }
}