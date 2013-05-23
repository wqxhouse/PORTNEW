using System.Windows;

namespace PORTAPP.UserSystem
{
    /// <summary>
    /// Description for RegisterWindow.
    /// </summary>
    public partial class RegisterWindow : Window
    {

        private RegisterWindowVM detailVM;
        /// <summary>
        /// Initializes a new instance of the RegisterWindow class.
        /// </summary>
        public RegisterWindow()
        {
            InitializeComponent();
            //get reference via datacontext
            detailVM = (RegisterWindowVM)DataContext;
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