using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using Microsoft.Practices.ServiceLocation;

namespace WineMVVM.View
{
    /// <summary>
    /// Description for UserInfoPanel.
    /// </summary>
    public partial class UserInfoPanel
    {
        //used to get reference already existed by datacontext
        ViewModel.UserInfoPanelVM2 panel;

        /// <summary>
        /// Initializes a new instance of the UserInfoPanel class.
        /// </summary>
        public UserInfoPanel()
        {
            //resolving bugs in Blend 4
            ViewModel.ViewModelLocatorHelper.CreateStaticViewModelLocatorForDesigner(this, new ViewModel.ViewModelLocator());

            InitializeComponent();

            //get the reference already existed
            panel = (ViewModel.UserInfoPanelVM2)DataContext;
        }

        private void UserList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (panel.SelectedUser == null)
            {
                return;
            }

            //Start handling dialog
            //Precondition detailVM is already created as a singleton. 
            //Else a new instance will be created
            var detailVM = ServiceLocator.Current.GetInstance<ViewModel.UserInfoDetailsVM>();
            //pass selcted user data to the detailVM.
            //PostCondition: detailVM received the SelectedUser data and expanded to its members
            Messenger.Default.Send<WineDataDomain.User>(panel.SelectedUser, "selectedUser");

            //this will automatically attach userinfodetails view to detailVM since datacontext
            UserInfoDetails detailWindow = new UserInfoDetails();
            
            detailWindow.Closed += (s, ea) =>
            {
                if (detailWindow.DialogResult == true)
                {
                    // Confirm changes
                    //this operation both save changes 
                    //also it returns the modified in order to update the view of UserInfoPanel
                    panel.SelectedUser = detailVM.SaveChanges();
                }

            };
            

            detailWindow.ShowDialog();
            
        }

        
    }
}