using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Data.SqlClient;
using System.Data.EntityClient;
using System.Data;

//TODO: Password needs encreption and salt 


namespace ServiceDataLib
{
    public class SqlUserRepository : WineDataDomain.IUserRepository
    {
        private readonly WineDataEntities _usersContext;

        public SqlUserRepository()
        {
            try
            {

                string conn = Conn.BuildConnectionString();
                _usersContext = new WineDataEntities(conn);
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
                                ("Query ptr failed"));
                }

                var domainUserList =
                           from p in userList
                           select p.ToDomainUser();

                callback(domainUserList, null);

            }
            catch (EntityException e)
            {
                callback(null, e.InnerException);
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
                    throw new FaultException(string.Format("Query ptr failed"));
                }

                var domainFriendList = 
                    from fl in friendList
                    select fl.ToDomainFriendList();

                callback(domainFriendList, null);

            }
            catch (EntityException e)
            {
                callback(null, e.InnerException);
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
            catch (EntityException e)
            {
                callback(null, e.InnerException);
            }
            catch(Exception e)
            {
                callback(null, e);
            }
        }


        public void IsExistedUser(string username, Action<bool, Exception> callback)
        {
            var user = from u in _usersContext.Users
                       where u.nickname == username
                       select u;


            if (user.Count() == 0)
            {
                callback(false, null);
            }
            else if (user.Count() == 1)
            {
                callback(true, null);
            }
            else
            {
                callback(false, new FaultException(string.Format("BUG:Database has multiple user with the same name, need to fix")));
            }
        }

        public void IsExistedUser(string username, string password, Action<bool, Exception> callback)
        {
            if (username == String.Empty || password == null)
            {
                callback(false, new FaultException(string.Format("BUG: Empty string for query. Need to fix validation")));
            }

            var user = from u in _usersContext.Users
                       where u.nickname == username
                       select u;

            if (user.Count() == 0)
            {
                callback(false, new FaultException(string.Format("BUG: No matching records!")));
            }
            else if (user.Count() == 1)
            {
                if(user.ToList()[0].password == password)
                {
                    callback(true, null);
                }
            }
            else
            {
                callback(false, new FaultException(string.Format("BUG:Database has multiple user with the same name, need to fix")));
            }
        }
    }
}
