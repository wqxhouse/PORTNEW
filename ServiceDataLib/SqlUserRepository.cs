using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ServiceDataLib
{
    public class SqlUserRepository : WineDataDomain.IUserRepository
    {
        private readonly UsersEntities _usersContext;

        public SqlUserRepository()
        {
            try
            {
                _usersContext = new UsersEntities();
            }
            catch
            {
                //connection string failed
                _usersContext = null;
            }
        }

        public void GetAllUserData(Action<IEnumerable<WineDataDomain.User>, Exception> callback)
        {
            if (_usersContext == null)
            {
                callback(null, new FaultException(string.Format
                                ("Database Connection Failed.")));
            }

            try
            {
                var userList = from p in _usersContext.Users.ToList()
                               select p;

                if (userList == null)
                {
                    throw new FaultException(string.Format
                                ("Empty "));
                }

                var domainUserList =
                           from p in userList
                           select p.ToDomainUser();

                callback(domainUserList, null);

            }
            catch (Exception e)
            {
                callback(null, e);
            }



        }

        public void GetFriendData(Action<IEnumerable<WineDataDomain.FriendList>, Exception> callback)
        {
            if (_usersContext == null)
            {
                callback(null, new FaultException(string.Format
                                ("Database Connection Failed.")));
            }

            try
            {
                var friendList = 
                    from fl in _usersContext.FriendStatuses.ToList()
                    select fl;

                if (friendList == null)
                {
                    throw new FaultException(string.Format("Empty"));
                }

                var domainFriendList = 
                    from fl in friendList
                    select fl.ToDomainFriendList();

                callback(domainFriendList, null);

            }
            catch (Exception e)
            {
                callback(null, e);
            }

        }

        public void UpdateUser(IEnumerable<WineDataDomain.User> modified, Action<String, Exception> callback)
        {
            if (_usersContext == null)
            {
                callback(null, new FaultException(string.Format
                                ("Database Connection Failed.")));
            }

            var modEntry = from u in modified
                           select u;

            foreach (WineDataDomain.User m in modEntry)
            {
                var mod = from ue in _usersContext.Users
                          where ue.user_id == m.ID
                          select ue;

                foreach(User u in mod){
                    u.UpdateFromDomainUser(m);
                }
            }

            try
            {
                _usersContext.SaveChanges();
                callback("Update Successfully!", null);
            }
            catch(Exception e)
            {
                callback(null, e);
            }
        }
    }
}
