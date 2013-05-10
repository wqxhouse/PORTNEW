using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Linq;
using Microsoft.Practices.ServiceLocation;

namespace WineMVVM.Background.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public sealed class UserInfoPanelVM2 : ViewModelBase
    {

        private ObservableCollection<WineDataDomain.User> _users;
        private ObservableCollection<WineDataDomain.User> _modifiedUsers;

        private readonly WineDataDomain.IUserRepository _repo;

        /// <summary>
        /// The <see cref="SelectedUser" /> property's name.
        /// </summary>
        public const string SelectedUserPropertyName = "SelectedUser";

        private WineDataDomain.User _selectedUser;

        /// <summary>
        /// Sets and gets the SelectedUser property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public WineDataDomain.User SelectedUser
        {
            get
            {
                return _selectedUser;
            }

            set
            {
                if (_selectedUser == value)
                {
                    return;
                }

                _selectedUser = value;
                RaisePropertyChanged(SelectedUserPropertyName);
                _modifiedUsers.Add(_selectedUser);
            }
        }

        /// <summary>
        /// The <see cref="Users" /> property's name.
        /// </summary>
        public const string UsersPropertyName = "Users";

        /// <summary>
        /// Sets and gets the Users property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<WineDataDomain.User> Users
        {
            get
            {
                return _users;
            }

            set
            {
                if (_users == value)
                {
                    return;
                }

                _users = value;
                RaisePropertyChanged(UsersPropertyName);
            }
        }


        /// <summary>
        /// Initializes a new instance of the UserInfoPanelVM class.
        /// </summary>
        public UserInfoPanelVM2(WineDataDomain.IUserRepository repo)
        {

            if (IsInDesignMode)
            {
                #region Populate Data
                Users = new ObservableCollection<WineDataDomain.User>();

                for (var index = 0; index < 15; index++)
                {
                    var newUser = new WineDataDomain.User
                    {
                        ID = index,
                        UserName = "SampleName",
                        PassWord = "SamplePassWD",
                        Email = "Sample@Email",
                        RegDate = new DateTime(),
                        
                    };

                    Users.Add(newUser);
                }
                #endregion
            }
            else
            {
                #region DataService
                _repo = repo;

                //dependancy injection on the service
               

                _repo.GetAllUserData((users, error) =>
                {
                    if (error != null)
                    {
                        MessageBox.Show(error.Message);
                    }
                    else
                    {
                        Users = new ObservableCollection<WineDataDomain.User>(users);
                    }
                });

                _modifiedUsers = new ObservableCollection<WineDataDomain.User>();

                #endregion


            }
        }

        public void updateDB(){
            _repo.UpdateUser(_modifiedUsers,
                (s, e) =>
                {
                    if (e != null)
                    {
                        MessageBox.Show(e.Message);
                    }

                    MessageBox.Show(s);
                });
        }



    }
}