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
                SimpleIoc.Default.Register<WineDataDomain.IJournalPageRepository, Design.SqlJournalPageRepository>();
                SimpleIoc.Default.Register<UserSystem.IUserState, UserSystem.UserState>();
            }

            #region pre-initialized ViewModels
            SimpleIoc.Default.Register<LogWindowVM>(true);

            SimpleIoc.Default.Register<WineJournal.WineJournalVM>(true);
            SimpleIoc.Default.Register<WineCellar.WineCellarVM>(true);
            SimpleIoc.Default.Register<WineCellar.WineRackVM>(true);
            SimpleIoc.Default.Register<CommentBoard.CommentBoardVM>(true);
            SimpleIoc.Default.Register<WineJournal.JournalEditorVM>(true);
            #endregion

            #region lazy-loaded VMs
            
            #endregion


            //Cautious: This needs to place at the last position, 
            //since this is not lazy loading and 
            //the ctor of MainViewModel needs the instances of VMs
            //above
            //SimpleIoc.Default.Register<MainViewModel>(true);
        
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
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}