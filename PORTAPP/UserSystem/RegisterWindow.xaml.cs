using System.Windows;
using Telerik.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Media.Imaging;
using System;

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

        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "All Image Files | *.*";
            if (dlg.ShowDialog() == true)
            {
                image.Source = new BitmapImage(new Uri(dlg.FileName, UriKind.Absolute));
                detailVM.PicUrl = image.Source;
            }
        }

        //private void radAutoCompleteBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        //{
        //    var autoCompleteBox = sender as RadAutoCompleteBox;
        //    if (autoCompleteBox != null)
        //    {
        //        var preferenceItems = autoCompleteBox.SelectedItems;
        //        string str = string.Empty;

        //        foreach(object o in preferenceItems)
        //        {
        //            var pref = o as Preference;
        //            if (pref != null)
        //            {
        //                str += pref.VarietalName + ",";
        //            }
        //        }

        //        Messenger.Default.Send<string>(str, "FromRegWindow_ToRegWindowVM_preferenceStr");
        //    }
        //}
    }
}