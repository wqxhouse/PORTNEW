using System.Windows;

namespace WineMVVM.Background.View
{
    /// <summary>
    /// Description for UserInfoDetails.
    /// </summary>
    public partial class UserInfoDetails
    {

        ViewModel.UserInfoDetailsVM detailVM;

        /// <summary>
        /// Initializes a new instance of the UserInfoDetails class.
        /// </summary>
        public UserInfoDetails()
        {
            ViewModel.ViewModelLocatorHelper.CreateStaticViewModelLocatorForDesigner(this, new ViewModel.ViewModelLocator());

            InitializeComponent();

            //get reference via datacontext
            detailVM = (ViewModel.UserInfoDetailsVM)DataContext;
            
        }

        private void Cancel_button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void OK_button_Click(object sender, RoutedEventArgs e)
        {
            if (detailVM.ValidateData())
            {
                this.DialogResult = true;
            }
            
        }
    }
}