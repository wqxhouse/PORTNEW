using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System;
using System.Windows;
using WineMVVM.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace WineMVVM.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class UserInfoPanelVM : ViewModelBase
    {

        private ObservableCollection<Database.User> _users;
        private readonly IUserDataService _dataService;

        private RelayCommand<object> _sendSelectedUserInfoCmd;

        /// <summary>
        /// Gets the SendSelectedUserInfoCmd.
        /// </summary>
        public RelayCommand<object> SendSelectedUserInfoCmd
        {
            get
            {
                return _sendSelectedUserInfoCmd
                    ?? (_sendSelectedUserInfoCmd = new RelayCommand<object>(
                                          selectedItem =>
                                          {
                                              var user = (Database.User)selectedItem;
                                              Messenger.Default.Send<NotificationMessage>(new NotificationMessage("ShowDetailWindow"));
                                              Messenger.Default.Send<Database.User>(user, "selectedUser");
                                              
                                              
                                          }));
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
        public ObservableCollection<Database.User> Users
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

                RaisePropertyChanging(UsersPropertyName);
                _users = value;
                RaisePropertyChanged(UsersPropertyName);
            }
        }


        /// <summary>
        /// Initializes a new instance of the UserInfoPanelVM class.
        /// </summary>
        public UserInfoPanelVM(IUserDataService service)
        {
            
            if (IsInDesignMode)
            {
                #region Populate Data
                Users = new ObservableCollection<Database.User>();

                for (var index = 0; index < 15; index++)
                {
                    var newUser = new Database.User
                    {
                        user_id = index,
                        nickname = "SampleName",
                        password = "SamplePassWD",
                        email = "Sample@Email",
                        reg_date = new DateTime(),
                        reg_ip = "127.0.0.1"
                    };

                    Users.Add(newUser);
                }
                #endregion
            }
            else
            {
                #region DataService
                _dataService = service;
                _dataService.GetData((users, error) =>
                {
                    if (error != null)
                    {
                        MessageBox.Show(error.Message);
                    }
                    else
                    {
                        Users = new ObservableCollection<Database.User>(users);
                    }
                });
                #endregion

                
            }
        }

        

    }
}