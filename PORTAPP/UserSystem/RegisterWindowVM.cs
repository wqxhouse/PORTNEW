using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows;

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
        private readonly WineDataDomain.IUserRepository _userRepo;
        private readonly WineDataDomain.IWineRepository _wineRepo;
        private readonly WineCatagory.WineCatagoryHandler catagoryHandler;

        /// <summary>
        /// Initializes a new instance of the RegisterWindowVM class.
        /// </summary>
        public RegisterWindowVM(WineDataDomain.IUserRepository userRepo, WineDataDomain.IWineRepository wineRepo)
        {
            //inject repo
            _userRepo = userRepo;
            _wineRepo = wineRepo;


            //Create catagory handler and pass wineRepo dependancy to it.
            catagoryHandler = new WineCatagory.WineCatagoryHandler(wineRepo);


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

            //load from database the user info to avoid same username
            _userRepo.GetAllUserData(
                (users, e) =>
                {
                    if (e != null)
                    {
                        MessageBox.Show(e.Message);
                    }
                    else
                    {
                        Users = new ObservableCollection<WineDataDomain.User>(users);
                    }
                });

            //initialize PreferenceList
            PreferenceList = new ObservableCollection<Preference>();

            //load from database the wine name and catagories to suggest
            //when filling in the preference field.
            //TODO: wine 
            PopulatePreferenceList();


        }


        #region private methods

        private void PopulatePreferenceList()
        {
            if (PreferenceList == null)
            {
                MessageBox.Show("DEBUG: PreferenceList not initialzed");
            }

            var association = catagoryHandler.GetWineTypeToVarietals();
            foreach (KeyValuePair<int, WineDataDomain.Refinement[]> i in association)
            {
                foreach (WineDataDomain.Refinement r in i.Value)
                {
                    PreferenceList.Add(new Preference(i.Key, r));
                }
            }

        }

        private void ExecuteRegister()
        {
            //TODO: exe register
        }

        #endregion

        #region properities

        /// <summary>
        /// The <see cref="PreferenceList" /> property's name.
        /// </summary>
        public const string PreferenceListPropertyName = "PreferenceList";

        private ObservableCollection<Preference> _preferenceList ;

        /// <summary>
        /// Sets and gets the PreferenceList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Preference> PreferenceList
        {
            get
            {
                return _preferenceList;
            }

            set
            {
                if (_preferenceList == value)
                {
                    return;
                }

                
                _preferenceList = value;
                RaisePropertyChanged(PreferenceListPropertyName);
            }
        }
        

        /// <summary>
        /// The <see cref="Users" /> property's name.
        /// </summary>
        public const string UsersPropertyName = "Users";

        private ObservableCollection<WineDataDomain.User> _users;

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

        #endregion


        #region IDataError
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