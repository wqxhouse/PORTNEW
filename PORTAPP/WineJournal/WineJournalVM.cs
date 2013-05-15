using GalaSoft.MvvmLight;
using ActiproSoftware.Windows;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.ComponentModel;

namespace PORTAPP.WineJournal
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class WineJournalVM : ViewModelBase, IPageViewModel
    {
        private WineDataDomain.IJournalPageRepository _repo;
        private UserSystem.IUserState _userState;



        /// <summary>
        /// Initializes a new instance of the WineJournalVM class.
        /// </summary>
        public WineJournalVM(UserSystem.IUserState userState, WineDataDomain.IJournalPageRepository repo)
        {
            if(IsInDesignMode)
            {

            }
            else
            {
                _repo = repo;
                _userState = userState;

                //Subscribing log info change
                Messenger.Default.Register<PropertyChangedMessage<bool>>(
                    this,
                    message =>
                    {
                        IsLoggedIn = message.NewValue;
                    });

                var currentUser = _userState.getUserState().LoggedInUserName;

                _repo.GetUserPages(currentUser,
                    (pages, e) =>
                    {
                        if (e != null)
                        {
                            MessageBox.Show(e.Message);
                        }

                        Pages = new DeferrableObservableCollection<WineDataDomain.JournalPage>();
                        foreach (WineDataDomain.JournalPage p in pages)
                        {
                            Pages.Add(p);
                        }

                    });
                
            }
           
        }



        #region properities

        /// <summary>
        /// The <see cref="IsBusy" /> property's name.
        /// </summary>
        public const string IsBusyPropertyName = "IsBusy";

        private bool _isBusy = false;

        /// <summary>
        /// Sets and gets the IsBusy property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                if (_isBusy == value)
                {
                    return;
                }

                _isBusy = value;
                RaisePropertyChanged(IsBusyPropertyName);
            }
        }


        public string Name
        {
            get { return "WineJournal"; }
        }

        /// <summary>
        /// The <see cref="Pages" /> property's name.
        /// </summary>
        public const string PagesPropertyName = "Pages";

        private DeferrableObservableCollection<WineDataDomain.JournalPage> _pages;

        /// <summary>
        /// Sets and gets the Pages property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DeferrableObservableCollection<WineDataDomain.JournalPage> Pages
        {
            get
            {
                return _pages;
            }

            set
            {
                if (_pages == value)
                {
                    return;
                }

               
                _pages = value;
                RaisePropertyChanged(PagesPropertyName);
            }
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

        #endregion
        
    }
}