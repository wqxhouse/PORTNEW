using System.Windows;

namespace WineMVVM.View
{
    /// <summary>
    /// Description for UserInfoDetails.
    /// </summary>
    public partial class UserInfoDetails : Navigation.IModalWindowView
    {
        /// <summary>
        /// Initializes a new instance of the UserInfoDetails class.
        /// </summary>
        public UserInfoDetails()
        {
            ViewModel.ViewModelLocatorHelper.CreateStaticViewModelLocatorForDesigner(this, new ViewModel.ViewModelLocator());

            InitializeComponent();
            
        }

        private void Cancel_button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void OK_button_Click(object sender, RoutedEventArgs e)
        { 
            this.DialogResult = true;       
        }
    }
}