namespace WineSearchBar
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Data;

    public class SearchFilterEventArgs : EventArgs
    {
        private FilterEventArgs filterEventArgs;

        internal SearchFilterEventArgs(string searchText, FilterEventArgs wrappedFilterEventArgs)
        {
            this.filterEventArgs = wrappedFilterEventArgs;
            this.SearchText = searchText;
        }

        public bool Accepted
        {
            get
            {
                return this.filterEventArgs.Accepted;
            }
            set
            {
                this.filterEventArgs.Accepted = value;
            }
        }

        public object Item
        {
            get
            {
                return this.filterEventArgs.Item;
            }
        }

        public string SearchText { get; private set; }
    }
}

