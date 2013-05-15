using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace PORTAPP.UserSystem
{
    public class UserState : ViewModelBase, IUserState
    {
        /// <summary>
        /// The <see cref="IsLoggedIn" /> property's name.
        /// </summary>
        public const string IsLoggedInPropertyName = "IsLoggedIn";

        private bool _isLoggedIn = false;

        /// <summary>
        /// Sets and gets the IsLoggedIn property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsLoggedIn
        {
            get
            {
                return _isLoggedIn;
            }

            set
            {
                if (_isLoggedIn == value)
                {
                    return;
                }

                var oldValue = _isLoggedIn;
                _isLoggedIn = value;

                //broadcast logged in message to all other VM's windows and usercontrols 
                RaisePropertyChanged(IsLoggedInPropertyName, oldValue, _isLoggedIn, true);
               
            }
        }

        /// <summary>
        /// The <see cref="LoggedInUserName" /> property's name.
        /// </summary>
        public const string LoggedInUserNamePropertyName = "LoggedInUserName";

        private string _loggedInUserName = "";

        /// <summary>
        /// Sets and gets the LoggedInUserName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string LoggedInUserName
        {
            get
            {
                return _loggedInUserName;
            }

            set
            {
                if (_loggedInUserName == value)
                {
                    return;
                }

                
                _loggedInUserName = value;
               
            }
        }


        public UserState getUserState()
        {
            return this;
        }
    }
}
