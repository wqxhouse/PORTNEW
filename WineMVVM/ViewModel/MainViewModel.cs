using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;


namespace WineMVVM.Background.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
       

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Messenger.Default.Register<NotificationMessage>(this, 
                m => {
                    if (m.Notification == "Logged In")
                    {
                        _isLoggedIn = true;
                    }
                    else if (m.Notification == "Offline")
                    {
                        _isLoggedIn = false;
                    }

                });
            
        }

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

                
                _isLoggedIn = value;
                RaisePropertyChanged(IsLoggedInPropertyName);
            }
        }

        

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}