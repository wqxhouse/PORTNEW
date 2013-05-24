/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:PORTAPP.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace PORTAPP.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                
                SimpleIoc.Default.Register<UserSystem.IUserState, Design.DesignUserState>();
                SimpleIoc.Default.Register<WineDataDomain.IUserRepository, Design.DesignUserRepository>();
                SimpleIoc.Default.Register<WineDataDomain.IJournalPageRepository, Design.DesignPageRepository>();
            }
            else
            {
                SimpleIoc.Default.Register<WineDataDomain.IUserRepository, ServiceDataLib.SqlUserRepository>();

                //temporarily mock
                SimpleIoc.Default.Register<WineDataDomain.IJournalPageRepository, Design.SqlJournalPageRepository>();

                SimpleIoc.Default.Register<UserSystem.IUserState, UserSystem.UserState>();
                
                //use design temporarily
                SimpleIoc.Default.Register<WineDataDomain.IWineRepository, Design.DesignWineRepository>();

            }

            #region pre-initialized ViewModels
            

            SimpleIoc.Default.Register<WineJournal.WineJournalVM>();
            SimpleIoc.Default.Register<WineCellar.WineCellarVM>();
            SimpleIoc.Default.Register<WineCellar.WineRackVM>();
            SimpleIoc.Default.Register<CommentBoard.CommentBoardVM>();
            SimpleIoc.Default.Register<WineJournal.JournalEditorVM>(true);

            SimpleIoc.Default.Register<UserSystem.UserPanelVM>();
            #endregion

            #region lazy-loaded VMs
            SimpleIoc.Default.Register<LogWindowVM>();

            SimpleIoc.Default.Register<UserSystem.RegisterWindowVM>();
            #endregion


            //Cautious: This needs to place at the last position, 
            //since this is not lazy loading and 
            //the ctor of MainViewModel needs the instances of VMs
            //above
            SimpleIoc.Default.Register<MainViewModel>(true);
        
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }



        /// <summary>
        /// Gets the WineJournalVM property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public WineJournal.WineJournalVM WineJournal
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WineJournal.WineJournalVM>();
            }
        }


        /// <summary>
        /// Gets the WineCellar property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public WineCellar.WineCellarVM WineCellar
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WineCellar.WineCellarVM>();
            }
        }



        /// <summary>
        /// Gets the WineRack property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public WineCellar.WineRackVM WineRack
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WineCellar.WineRackVM>();
            }
        }

            

        /// <summary>
        /// Gets the CommentBoard property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public CommentBoard.CommentBoardVM CommentBoard
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CommentBoard.CommentBoardVM>();
            }
        }



        /// <summary>
        /// Gets the LogInWindow property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public LogWindowVM LogInWindow
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LogWindowVM>();
            }
        }

        /// <summary>
        /// Gets the JournalEditor property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public WineJournal.JournalEditorVM JournalEditor
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WineJournal.JournalEditorVM>();
            }
        }



        /// <summary>
        /// Gets the LogWindow property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public LogWindowVM LogWindow
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LogWindowVM>();
            }
        }



        /// <summary>
        /// Gets the UserPanel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public UserSystem.UserPanelVM UserPanel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserSystem.UserPanelVM>();
            }
        }



        /// <summary>
        /// Gets the RegisterWindow property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public UserSystem.RegisterWindowVM RegisterWindow
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserSystem.RegisterWindowVM>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}