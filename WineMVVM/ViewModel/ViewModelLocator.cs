/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:WineMVVM.Background.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

using System.Configuration;
using System;

namespace WineMVVM.Background.ViewModel
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
                SimpleIoc.Default.Register<WineDataDomain.IUserRepository, Design.DesignDataService>();
            }
            else
            {
                //couple ServiceData Lib with Client. 
                //can be resovled with a WCF service or WCF Data Service using OData
                //Correct dependancy, ServiceDataLib -> Domain <- Client
                SimpleIoc.Default.Register<WineDataDomain.IUserRepository, ServiceDataLib.SqlUserRepository>();
                //SimpleIoc.Default.Register<WineDataDomain.UserRepository, >();
                //SimpleIoc.Default.Register<WineDataDomain.IUserRepository, UserDataService>();
                //SimpleIoc.Default.Register<IModalDialogService, ModalDialogService>();
                
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ControllerMenuVM>();
            //SimpleIoc.Default.Register<UserInfoPanelVM>();
            SimpleIoc.Default.Register<UserInfoPanelVM2>();

            //Do not lazy load UserInfoDetailsVM since it involves getting Data from startUp.
            SimpleIoc.Default.Register<UserInfoDetailsVM>(true);

            //SimpleIoc.Default.Register<Navigation.IModalWindowView, View.UserInfoDetails>();
        }

        //private static WineDataDomain.UserRepository CreateRepository()
        //{
        //    string connectionString =   
        //        ConfigurationManager.ConnectionStrings
        //        ["UsersEntities"].ConnectionString;

        //    string userRepositoryTypeName =
        //        ConfigurationManager.AppSettings
        //        ["UserRepositoryType"];

        //    var userRepositoryType =
        //        Type.GetType(userRepositoryTypeName, true);
        //    var repository =
        //        (WineDataDomain.UserRepository)Activator.CreateInstance(
        //        userRepositoryType, connectionString);
            
        //    return repository;
        //}



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
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }


        /// <summary>
        /// Gets the ControllerMenu property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ControllerMenuVM ControllerMenu
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ControllerMenuVM>();
            }
        }

       
        /// <summary>
        /// Gets the UserInfoPanel property.
        /// </summary>
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        //    "CA1822:MarkMembersAsStatic",
        //    Justification = "This non-static member is needed for data binding purposes.")]
        //public UserInfoPanelVM UserInfoPanel
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<UserInfoPanelVM>();
        //    }
        //}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
           "CA1822:MarkMembersAsStatic",
           Justification = "This non-static member is needed for data binding purposes.")]
        public UserInfoPanelVM2 UserInfoPanel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserInfoPanelVM2>();
            }
        }

        /// <summary>
        /// Gets the UserInfoDetails property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public UserInfoDetailsVM UserInfoDetails
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserInfoDetailsVM>();
            }
        }
    }
}