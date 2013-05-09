using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Linq;
using Microsoft.Practices.ServiceLocation;

namespace WineMVVM.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public sealed class UserInfoPanelVM : ViewModelBase
    {

        private ObservableCollection<Database.User> _users;
        private readonly Service.IUserDataService _dataService;
        
       // private readonly Service.IModalDialogService _dialogService;

        //private RelayCommand<object> _sendSelectedUserInfoCmd;

        /// <summary>
        /// Gets the EditUser.
        /// </summary>
        /// 
        //public RelayCommand<object> EditUser
        //{
        //    get
        //    {
        //        return _sendSelectedUserInfoCmd
        //            ?? (_sendSelectedUserInfoCmd = new RelayCommand<object>(
        //                                  selectedItem =>
        //                                  {
        //                                      Navigation.IModalWindowView userDetailView = ServiceLocator.Current.GetInstance<Navigation.IModalWindowView>();
        //                                      var userSelected = (Database.User)selectedItem;
        //                                      //Messenger.Default.Send<Database.User>(user, "dataToDetailService");
        //                                      //Messenger.Default.Send<NotificationMessage>(new NotificationMessage("ShowDetailWindow"));           
        //                                      this._dialogService.ShowDialog<UserInfoDetailsVM>
        //                                          (userDetailView, new UserInfoDetailsVM(userSelected),
        //                                          modifiedUser =>
        //                                          {
        //                                              if (userDetailView.DialogResult.HasValue && userDetailView.DialogResult.Value)
        //                                              {
        //                                                  var oldItem = this.Users.FirstOrDefault(u => u.user_id == userSelected.user_id);
        //                                                  var oldPos = this.Users.IndexOf(oldItem);
        //                                                  if (oldPos > -1)
        //                                                  {
        //                                                      this.Users.RemoveAt(oldPos);
        //                                                      this.Users.Insert(oldPos, modifiedUser.ToDataBaseModel());
        //                                                  }
        //                                              }
        //                                          });
                                                    
                                                   
        //                                    }));
                                               
        //    }

            
        //}

        /// <summary>
        /// The <see cref="SelectedUser" /> property's name.
        /// </summary>
        public const string SelectedUserPropertyName = "SelectedUser";

        private Database.User _selectedUser;

        /// <summary>
        /// Sets and gets the SelectedUser property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Database.User SelectedUser
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

                RaisePropertyChanging(SelectedUserPropertyName);
                _selectedUser = value;
                RaisePropertyChanged(SelectedUserPropertyName);
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
        public UserInfoPanelVM(Service.IUserDataService user_dataservice)
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
                _dataService = user_dataservice;
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