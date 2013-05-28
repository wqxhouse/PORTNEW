using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows;
using System;
using System.Windows.Media;

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
        private readonly IUserState _userState;
        private readonly WineCatagory.WineCatagoryHandler catagoryHandler;

        /// <summary>
        /// Initializes a new instance of the RegisterWindowVM class.
        /// </summary>
        public RegisterWindowVM(WineDataDomain.IUserRepository userRepo, 
                                WineDataDomain.IWineRepository wineRepo, 
                                IUserState userState)
        {

            if (IsInDesignMode)
            {
                UserName = "Test";
                Password = "123";
                Email = "ABC@hotmail.com";
            }
            else
            {
                //inject repo
                _userRepo = userRepo;
                _wineRepo = wineRepo;
                _userState = userState;


                //Create catagory handler and pass wineRepo dependancy to it.
                catagoryHandler = new WineCatagory.WineCatagoryHandler(wineRepo);


                //receive register action upon receiving register notification from LogWindow
                Messenger.Default.Register<NotificationMessageAction<bool>>
                    (this,
                    "FromLogWindow_ToRegisterWindowVM_regMsg",
                    m =>
                    {
                        if (m.Notification == "Perform Register")
                        {
                            executeRegister(m);
                        }
                    });


                //Messenger.Default.Register<string>
                //    (this,
                //    "FromRegWindow_ToRegWindowVM_preferenceStr",
                //    s =>
                //    {

                //    });

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

                //initialize DataBase PreferenceList
                PreferenceList = new ObservableCollection<Preference>();

                //initialize User PreferenceItems
                UserPreferences = new ObservableCollection<Preference>();


                //load from database the wine name and catagories to suggest
                //when filling in the preference field.
                //TODO: wine 
                populatePreferenceList();
            }

        }


        #region private methods

        private void populatePreferenceList()
        {
            if (PreferenceList == null)
            {
                MessageBox.Show("DEBUG: PreferenceList not pre-initialzed, initializing...");

                //initialize DataBase PreferenceList
                PreferenceList = new ObservableCollection<Preference>();
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

        private string convertPreferenceToString()
        {
            string prefStr = string.Empty;

            if(UserPreferences.Count == 0)
            {
                MessageBox.Show("DEBUG: Expect non preference be handled by validation()");
            }
            foreach(Preference p in UserPreferences)
            {
                prefStr += p.VarietalName + ",";
            }

            return prefStr;
        }

        private void clearFields()
        {
            UserName = "";
            Password = "";
            Email = "";
            UserPreferences.Clear();
            //TODO: More fields needs to be cleared
        }

        private void executeRegister(NotificationMessageAction<bool> callbackAction)
        {
            //TODO: exe register
            var newUser = new WineDataDomain.User()
            {
                UserName = this.UserName,
                PassWord = this.Password,
                Preference = convertPreferenceToString(),
                RegDate = DateTime.Now,
                PicUrl = this.PicUrl,
                ZipCode = this.ZipCode

            };

            _userRepo.CreateNewUser(
                newUser, 
                (b, e) =>
                    {
                        if(b != true)
                        {
                            MessageBox.Show("Register Failed " + e.Message);
                            clearFields();

                            //pass back to log window the failure message
                            callbackAction.Execute(false);
                            return;

                        }
                        else
                        {
                            MessageBox.Show("Register Successfully!");
                            clearFields();

                            //pass back the successful message
                            callbackAction.Execute(true);
                            return;
                        }
                    });

            //redirect to the main page logged in
            _userState.getUserState().IsLoggedIn = true;
            _userState.getUserState().LoggedInUserName = this.UserName;
            
        }

        #endregion

        #region properities

        /// <summary>
        /// The <see cref="ZipCode" /> property's name.
        /// </summary>
        public const string ZipCodePropertyName = "ZipCode";

        private int _zipCode = 0;

        /// <summary>
        /// Sets and gets the ZipCode property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ZipCode
        {
            get
            {
                return _zipCode;
            }

            set
            {
                if (_zipCode == value)
                {
                    return;
                }

                _zipCode = value;
                RaisePropertyChanged(ZipCodePropertyName);
            }
        }


        /// <summary>
        /// The <see cref="PicUrl" /> property's name.
        /// </summary>
        public const string PicUrlPropertyName = "PicUrl";

        private ImageSource _myProperty;

        /// <summary>
        /// Sets and gets the PicUrl property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ImageSource PicUrl
        {
            get
            {
                return _myProperty;
            }

            set
            {
                if (_myProperty == value)
                {
                    return;
                }

                
                _myProperty = value;
                RaisePropertyChanged(PicUrlPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="UserPreferences" /> property's name.
        /// </summary>
        public const string UserPreferencesPropertyName = "UserPreferences";

        private ObservableCollection<Preference> _userPreferences  ;

        /// <summary>
        /// Sets and gets the UserPreferences property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Preference> UserPreferences
        {
            get
            {
                return _userPreferences;
            }

            set
            {
                if (_userPreferences == value)
                {
                    return;
                }

                
                _userPreferences = value;
                RaisePropertyChanged(UserPreferencesPropertyName);
            }
        }


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