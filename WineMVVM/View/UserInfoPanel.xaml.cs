using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace WineMVVM.View
{
    /// <summary>
    /// Description for UserInfoPanel.
    /// </summary>
    public partial class UserInfoPanel
    {
        /// <summary>
        /// Initializes a new instance of the UserInfoPanel class.
        /// </summary>
        public UserInfoPanel()
        {
            //resolving bugs in Blend 4
            ViewModel.ViewModelLocatorHelper.CreateStaticViewModelLocatorForDesigner(this, new ViewModel.ViewModelLocator());

            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, OpenUserDetailWindow);
        }

        private void OpenUserDetailWindow(NotificationMessage msg)
        {
            if (msg.Notification == "ShowDetailWindow")
            {

                var details = new UserInfoDetails();
                details.ShowDialog();
            }
        }
    }
}