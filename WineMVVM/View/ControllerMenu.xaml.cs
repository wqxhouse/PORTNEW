using System.Windows;

namespace WineMVVM.View
{
    /// <summary>
    /// Description for ControllerMenu.
    /// </summary>
    public partial class ControllerMenu
    {
        /// <summary>
        /// Initializes a new instance of the ControllerMenu class.
        /// </summary>
        public ControllerMenu()
        {
            //resolving bugs in Blend 4
            ViewModel.ViewModelLocatorHelper.CreateStaticViewModelLocatorForDesigner(this, new ViewModel.ViewModelLocator());

            InitializeComponent();
        }
    }
}