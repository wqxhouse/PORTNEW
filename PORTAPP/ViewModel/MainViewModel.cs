using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Messaging;

namespace PORTAPP.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public sealed class MainViewModel : ViewModelBase
    {
        #region Fields

        private RelayCommand<object> _changePageCommand;

        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        #endregion

        private UserSystem.IUserState _userState;

        public MainViewModel(UserSystem.IUserState userState)
        {
           
            _userState = userState;

            #region Receive userState update message
            

            #endregion

            var logInfo = _userState.getUserState().IsLoggedIn;

            IsLoggedIn = logInfo;


            // Subscribing Log In info change
            Messenger.Default.Register<PropertyChangedMessage<bool>>(
                    this,
                    message =>
                    {
                        IsLoggedIn = message.NewValue;
                    });


            // Add available pages
            PageViewModels.Add(ServiceLocator.Current.GetInstance<Recommendation.RecommendationMainVM>());
            PageViewModels.Add(ServiceLocator.Current.GetInstance<WineCellar.WineCellarVM>());
            PageViewModels.Add(ServiceLocator.Current.GetInstance<WineJournal.WineJournalVM>());
            PageViewModels.Add(ServiceLocator.Current.GetInstance<CommentBoard.CommentBoardVM>());
            

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];

            
        }

        #region Properties / Commands

        public RelayCommand<object> ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand<object>(
                        p => ChangeViewModel((IPageViewModel)p),
                        p => p is IPageViewModel);
                }

                return _changePageCommand;
            }
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    var oldValue = _currentPageViewModel;
                    _currentPageViewModel = value;

                    //broadcast to MainWindow.xaml.cs
                    RaisePropertyChanged("CurrentPageViewModel", oldValue, _currentPageViewModel, true);
                }
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

                //var oldValue = _isLoggedIn;
                _isLoggedIn = value;

                //broadcast logged in message to all other VM's windows and usercontrols 
                //RaisePropertyChanged(IsLoggedInPropertyName, oldValue, _isLoggedIn, true);
                RaisePropertyChanged(IsLoggedInPropertyName);
            }
        }

        #endregion

        #region Methods

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        #endregion
    }
}