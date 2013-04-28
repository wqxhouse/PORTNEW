using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace WineMVVM.Model
{
    public class UserDataService : IUserDataService
    {
        private ObservableCollection<Database.User> viewModelData;

        public void GetData(Action<IEnumerable<Database.User>, Exception> callback)
        {
            viewModelData = new ObservableCollection<Database.User>();

            var usersContext = new Database.UsersEntities();
                var userList = from p in usersContext.Users.ToList()
                               select p;
            
                foreach(Database.User user in userList){
                    viewModelData.Add(user);
                }
            

            //needs exception handling
            callback(viewModelData, null);
        }

    }
}