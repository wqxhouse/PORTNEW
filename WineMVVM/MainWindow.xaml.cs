using System.Windows;
using WineMVVM.ViewModel;

namespace WineMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            //resolving bugs in Blend 4
            ViewModelLocatorHelper.CreateStaticViewModelLocatorForDesigner(this, new ViewModelLocator());

            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}