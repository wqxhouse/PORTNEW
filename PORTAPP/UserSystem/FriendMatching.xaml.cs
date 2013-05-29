using System.Windows;
using System.Windows.Controls;

namespace PORTAPP.UserSystem
{
    /// <summary>
    /// Description for FriendMatching.
    /// </summary>
    public partial class FriendMatching : Window
    {

        private readonly FriendMatchingVM friendMatchingVM;
        /// <summary>
        /// Initializes a new instance of the FriendMatching class.
        /// </summary>
        public FriendMatching()
        {
            InitializeComponent();

            friendMatchingVM = (FriendMatchingVM)DataContext;

        }

        private void OnFilterBoxTextChanged(object sender, TextChangedEventArgs e)
        {

            friendMatchingVM.FilterText = (sender as TextBox).Text;
        }
    }
}