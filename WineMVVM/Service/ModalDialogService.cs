using GalaSoft.MvvmLight;
using System;

namespace WineMVVM.Service
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ModalDialogService : IModalDialogService
    {
        public void ShowDialog<TDialogViewModel>(Navigation.IModalWindowView view, TDialogViewModel viewModel, Action<TDialogViewModel> onDialogClose)
        {
            view.DataContext = viewModel;
            if (onDialogClose != null)
            {
                view.Closed += (sender, e) => onDialogClose(viewModel);
            }
            view.ShowDialog();
        }

        public void ShowDialog<TDialogViewModel>(Navigation.IModalWindowView view, TDialogViewModel viewModel)
        {
            this.ShowDialog(view, viewModel, null);
        }
    }

}