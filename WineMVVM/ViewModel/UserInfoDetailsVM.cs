using GalaSoft.MvvmLight;
using System;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace WineMVVM.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class UserInfoDetailsVM : ViewModelBase
    {

        public RelayCommand ConfirmCmd { get; private set; }
        private Database.User _userInstance;

        /// <summary>
        /// Initializes a new instance of the UserInfoDetails class.
        /// </summary>
        public UserInfoDetailsVM()
        {
            if (!IsInDesignMode)
            {
                //Messenger.Default.Register<ObservableCollection<Database.User>>(this, "UserInfo"
                Messenger.Default.Register<Database.User>(this, "selectedUser", getUserInfo);

                ConfirmCmd = new RelayCommand(Confirm, () => { return ValidateData(); });
            }
        }

        private void getUserInfo(Database.User user)
        {
            _userInstance = user;
            _id = user.user_id;
            _userName = user.nickname;
            _password = user.password;
            _email = user.email;
            _regDate = user.reg_date;
            _regIp = user.reg_ip;
        }

        private bool ValidateData(){
            throw new NotImplementedException();
        }


        #region Property
        /// <summary>
        /// The <see cref="ID" /> property's name.
        /// </summary>
        public const string IDPropertyName = "ID";

        private int _id = 0;

        /// <summary>
        /// Sets and gets the ID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ID
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// The <see cref="UserName" /> property's name.
        /// </summary>
        public const string UserNamePropertyName = "UserName";

        private string _userName = "";

        /// <summary>
        /// Sets and gets the UserName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                if (_userName == value)
                {
                    return;
                }

                RaisePropertyChanging(UserNamePropertyName);
                _userName = value;
                RaisePropertyChanged(UserNamePropertyName);

                Messenger.Default.Send<string>(UserName, "UserName");
            }
        }

        /// <summary>
        /// The <see cref="Password" /> property's name.
        /// </summary>
        public const string PasswordPropertyName = "Password";

        private string _password = "";

        /// <summary>
        /// Sets and gets the Password property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                if (_password == value)
                {
                    return;
                }

                RaisePropertyChanging(PasswordPropertyName);
                _password = value;
                RaisePropertyChanged(PasswordPropertyName);
            }
        }
        

        /// <summary>
        /// The <see cref="Email" /> property's name.
        /// </summary>
        public const string EmailPropertyName = "Email";

        private string _email = "";

        /// <summary>
        /// Sets and gets the Email property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                if (_email == value)
                {
                    return;
                }

                RaisePropertyChanging(EmailPropertyName);
                _email = value;
                RaisePropertyChanged(EmailPropertyName);

                Messenger.Default.Send<string>(Email, "Email");
            }
        }

        /// <summary>
        /// The <see cref="RegDate" /> property's name.
        /// </summary>
        public const string RegDatePropertyName = "RegDate";

        private DateTime _regDate = new DateTime();

        /// <summary>
        /// Sets and gets the RegDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime RegDate
        {
            get
            {
                return _regDate;
            }
        }

        /// <summary>
        /// The <see cref="RegIp" /> property's name.
        /// </summary>
        public const string RegIpPropertyName = "RegIp";

        private string _regIp = "";

        /// <summary>
        /// Sets and gets the RegIp property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string RegIp
        {
            get
            {
                return _regIp;
            }
        }
        #endregion


        #region Commands
        private void Confirm()
        {
            Messenger.Default.Send<Database.User>(_userInstance, "modifiedUser");
        }
        #endregion

    }
}