using GalaSoft.MvvmLight;
using System;

namespace WineMVVM.Navigation
{

    public interface IModalWindowView
    {

        bool? DialogResult { get; set; }
        event EventHandler Closed;
        void Show();
        bool? ShowDialog();
        object DataContext { get; set; }
        void Close();

    }


}