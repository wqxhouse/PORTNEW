using GalaSoft.MvvmLight;
using System;

namespace WineMVVM.Service
{

    public interface IModalDialogService
    {

        void ShowDialog<TViewModel>(Navigation.IModalWindowView view, TViewModel viewModel, Action<TViewModel> onDialogClose);

        void ShowDialog<TDialogViewModel>(Navigation.IModalWindowView view, TDialogViewModel viewModel);

    }
}