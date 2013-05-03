using GalaSoft.MvvmLight;
using System;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace WineMVVM.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class UserInfoDetailsVM : ViewModelBase, IDataErrorInfo
    {
        private Database.User _userInstance;
      
        #region Commands
        private RelayCommand<bool?> _confirmCmd;

        /// <summary>
        /// Gets the ConfirmCmd.
        /// </summary>
        public RelayCommand<bool?> ConfirmCmd
        {
            get
            {
                return _confirmCmd
                    ?? (_confirmCmd = new RelayCommand<bool?>(
                                          (dialogResult) =>
                                          {
                                              
                                              dialogResult = true;
                                          }));
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the UserInfoDetails class.
        /// </summary>
        public UserInfoDetailsVM(Database.User user)
        {
            if (!IsInDesignMode)
            {
                ////get user info from selected column in the UserInfoPanel
                //Messenger.Default.Register<Database.User>(this, "selectedUser", expandUserInfo);
                expandUserInfo(user);
            }
        }


        private void expandUserInfo(Database.User user)
        {
            
            _id = user.user_id;
            _userName = user.nickname;
            _password = user.password;
            _email = user.email;
            _regDate = user.reg_date;
            _regIp = user.reg_ip;
            
            /* Needs improvement
             * Current objective: fire raiseproperitychanged to reflect
             * changes when the private field is set via messenger injection
             * since we require the properity field to be readonly
             * we cannot set properity directly
             * Here is a compromise way to update the changes onto Views
             * via raisepropertychanged
             
            /*
            RaisePropertyChanged(IDPropertyName);
            RaisePropertyChanged(UserNamePropertyName);
            RaisePropertyChanged(PasswordPropertyName);
            RaisePropertyChanged(EmailPropertyName);
            RaisePropertyChanged(RegDatePropertyName);
            RaisePropertyChanged(RegIpPropertyName);
             */
        }
    


        #region Property

        /// <summary>
        /// The <see cref="UserInstance" /> property's name.
        /// </summary>
        public const string UserInstancePropertyName = "UserInstance";

   

        /// <summary>
        /// Sets and gets the UserInstance property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Database.User UserInstance
        {
            get
            {
                return _userInstance;
            }

            set
            {
                if (_userInstance == value)
                {
                    return;
                }

                RaisePropertyChanging(UserInstancePropertyName);
                _userInstance = value;
                RaisePropertyChanged(UserInstancePropertyName);
            }
        }

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
                this.ClearError("Name");
                _userName = (string)value.Clone();
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
                this.ClearError("Name");
                _password = (string)value.Clone();
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
                this.ClearError("Name");
                _email = (string)value.Clone();
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

        #region IDataErrorInfo Members

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                if (this.errors.ContainsKey(columnName))
                {
                    return this.errors[columnName];
                }
                return string.Empty;
            }
        }

        #endregion


        #region Validation
        private Dictionary<string, string> errors = new Dictionary<string, string>();

        public void SetError(string propertyName, string errorMessage)
        {
            errors[propertyName] = errorMessage;
            this.RaisePropertyChanged(propertyName);
        }

        private void ClearError(string propertyName)
        {
            this.errors.Remove(propertyName);
        }

        private void ClearAllErrors()
        {
            List<string> properties = new List<string>();
            foreach (KeyValuePair<string, string> error in this.errors)
            {
                properties.Add(error.Key);
            }
            this.errors.Clear();
            foreach (string property in properties)
            {
                this.RaisePropertyChanged(property);
            }
        }

        private bool ValidateData()
        {
            bool isValid = true;
			this.ClearAllErrors();
			if (string.IsNullOrEmpty(this.UserName))
			{
				isValid = false;
				this.SetError("Name", "need a name");
			}
            if(string.IsNullOrEmpty(this.Password))
			{
				isValid = false;
				this.SetError("Password", "need a password");
			}
			if(string.IsNullOrEmpty(this.Email))
			{
				isValid = false;
				this.SetError("Email", "need an email");
			}
			return isValid;
        }
        #endregion

        #region To Database model conversion
        public Database.User ToDataBaseModel()
        {
            _userInstance.nickname = this.UserName;
            _userInstance.password = this.Password;
            _userInstance.email = this.Email;
            return _userInstance;

        }
        #endregion

    }
}