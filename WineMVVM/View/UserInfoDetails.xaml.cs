using System.Windows;

namespace WineMVVM.View
{
    /// <summary>
    /// Description for UserInfoDetails.
    /// </summary>
    public partial class UserInfoDetails : Window
    {
        /// <summary>
        /// Initializes a new instance of the UserInfoDetails class.
        /// </summary>
        public UserInfoDetails()
        {
            ViewModel.ViewModelLocatorHelper.CreateStaticViewModelLocatorForDesigner(this, new ViewModel.ViewModelLocator());

            InitializeComponent();
        }
    }
}