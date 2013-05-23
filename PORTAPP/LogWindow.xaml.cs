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

        private LogWindowVM logWindowVM;
        /// <summary>
        /// Initializes a new instance of the LogWindow class.
        /// </summary>
        public LogWindow()
        {
            ViewModel.ViewModelLocatorHelper.
                CreateStaticViewModelLocatorForDesigner
                (this, new ViewModel.ViewModelLocator());

            InitializeComponent();

            logWindowVM = (LogWindowVM)DataContext;

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

        private void Register_butn_Click(object sender, RoutedEventArgs e)
        {
            //Start handling dialog
            //Precondition detailVM is already created as a singleton. 
            //Else a new instance will be created
            var registerWindowVM = ServiceLocator.Current.GetInstance<UserSystem.RegisterWindowVM>();

            //this will automatically attach userinfodetails view to detailVM since datacontext
            UserSystem.RegisterWindow regWindow = new UserSystem.RegisterWindow();

            regWindow.Closed += (s, ea) =>
            {
                if (regWindow.DialogResult == true)
                {
                    Messenger.Default.Send<NotificationMessage>
                        (new NotificationMessage("Perform Register"), "FromLogWindow_ToRegisterWindowVM_regMsg");

                }

            };


            regWindow.ShowDialog();
        }


    }
}