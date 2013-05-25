using System.Windows;

namespace PORTAPP.SearchEngine
{
    /// <summary>
    /// Description for SearchBar.
    /// </summary>
    public partial class SearchBar
    {
        /// <summary>
        /// Initializes a new instance of the SearchBar class.
        /// </summary>
        public SearchBar()
        {
            InitializeComponent();
        }

        private void OnExampleSearchFilter(object sender, WineSearchBar.SearchFilterEventArgs e)
        {
            e.Accepted = true;
            


        }

        private void OnExampleSearchSearchSelection(object sender, WineSearchBar.SearchSelectionEventArgs e)
        {

            

        }
    }
}