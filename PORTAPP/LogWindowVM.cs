using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Diagnostics;
using System.Security;

namespace PORTAPP
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class LogWindowVM : ViewModelBase
    {

        private WineDataDomain.IUserRepository _repo;
        /// <summary>
        /// Initializes a new instance of the LogWindowVM class.
        /// </summary>
        public LogWindowVM(WineDataDomain.IUserRepository repo)
        {
            if (IsInDesignMode)
            {
                #region mock data

                UserName = "BlendMode";
                Password = "BlendMode";
                    
                #endregion
            }
            else
            {
                _repo = repo;
                
            }

        }

        #region properties

        /// <summary>
        /// The <see cref="UserName" /> property's name.
        /// </summary>
        public const string UserNamePropertyName = "UserName";

        private string _username = "";

        /// <summary>
        /// Sets and gets the UserName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string UserName
        {
            get
            {
                return _username;
            }

            set
            {
                if (_username == value)
                {
                    return;
                }

                
                _username = value;
                RaisePropertyChanged(UserNamePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Password" /> property's name.
        /// </summary>
        public const string PasswordPropertyName = "Password";

        private string _password;

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

                
                _password = value;
                RaisePropertyChanged(PasswordPropertyName);
            }
        }

#endregion

        #region Cmd
        private RelayCommand _loginCmd;

        /// <summary>
        /// Gets the LoginCmd.
        /// </summary>
        public RelayCommand LoginCmd
        {
            get
            {
                return _loginCmd
                    ?? (_loginCmd = new RelayCommand(ExecuteLoginCmd));
            }
        }

        private void ExecuteLoginCmd()
        {
            _repo.IsExistedUser(_username, _password, 
                (isExisted, e)=>
                {
                    if (isExisted)
                    {
                        MessageBox.Show("DEBUG: Logged In.");
                        Messenger.Default.Send<NotificationMessage>(
                            new NotificationMessage("Logged In"), "ToLogWindow_LogInfo");
                    }
                    else
                    {
                        MessageBox.Show("DEBUG: " + e.Message);
                        Process.GetCurrentProcess().Kill();
                    }
                });
        }
        #endregion
    }
}