namespace WineSearchBar
{
    using System;
    using System.Runtime.CompilerServices;

    public class SearchSelectionEventArgs : EventArgs
    {
        public SearchSelectionEventArgs(object selectedItem)
        {
            this.SelectedItem = selectedItem;
        }

        public object SelectedItem { get; private set; }
    }
}

