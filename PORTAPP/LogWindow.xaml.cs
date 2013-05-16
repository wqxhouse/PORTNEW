using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;

namespace PORTAPP
{
    /// <summary>
    /// Description for LogWindow.
    /// </summary>
    public partial class LogWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the LogWindow class.
        /// </summary>
        public LogWindow()
        {    
            ViewModel.ViewModelLocatorHelper.
                CreateStaticViewModelLocatorForDesigner
                (this, new ViewModel.ViewModelLocator());

            InitializeComponent();

            Messenger.Default.Register<NotificationMessage>(
                this,
                "ToLogWindow_LogInfo",
                m =>
                {
                    if (m.Notification == "Logged In")
                    {       
                        ExecuteAppLoggedIn();                       
                    }
                });
        }

        private void ExecuteAppLoggedIn()
        {
            
            var mainVM = ServiceLocator.Current.GetInstance<ViewModel.MainViewModel>();
            //Messenger.Default.Send<NotificationMessage>(
            //    new NotificationMessage("Logged In"), "ToMainViewModel_LogInfo");
            var mainWindow = new MainWindow();
            mainWindow.Show();

            //needs to be more well handled
            this.Close();

        }


    }
}