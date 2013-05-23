using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;

namespace PORTAPP.UserSystem
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class RegisterWindowVM : ViewModelBase, IDataErrorInfo
    {
        /// <summary>
        /// Initializes a new instance of the RegisterWindowVM class.
        /// </summary>
        public RegisterWindowVM()
        {

            //receive register action upon receiving register notification from LogWindow
            Messenger.Default.Register<NotificationMessage>
                (this, 
                "FromLogWindow_ToRegisterWindowVM_regMsg",
                m =>
                    {
                        if(m.Notification == "Perform Register"){
                            ExecuteRegister();
                        }
                    });
        }

        private void ExecuteRegister()
        {
            
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


                this.ClearError("Name");
                _userName = (string)value.Clone();
                RaisePropertyChanged(UserNamePropertyName);

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

               
                this.ClearError("Name");
                _email = (string)value.Clone();
                RaisePropertyChanged(EmailPropertyName);

                
            }
        }

        public string Error
        {
            get { throw new System.NotImplementedException(); }
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

        public bool ValidateData()
        {
            bool isValid = true;
            this.ClearAllErrors();
            if (string.IsNullOrEmpty(this.UserName))
            {
                isValid = false;
                this.SetError("Name", "need a name");
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                isValid = false;
                this.SetError("Password", "need a password");
            }

            if (string.IsNullOrEmpty(this.Email))
            {
                isValid = false;
                this.SetError("Email", "need an email");
            }
            return isValid;
        }

        #endregion
    }
}