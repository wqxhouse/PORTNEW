using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace PORTAPP.WineJournal
{
    /// <summary>
    /// Description for WineJournal.
    /// </summary>
    public partial class WineJournal
    {

        private WineJournalVM journalVM;

        
        /// <summary>
        /// Initializes a new instance of the WineJournal class.
        /// </summary>
        public WineJournal()
        {
            InitializeComponent();
            journalVM = (WineJournalVM)DataContext;
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("back: "+book.SelectedBackIndex + "front: " + book.SelectedFrontIndex);
            
        }

        private void book_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("" + book.SelectedFrontIndex);


            var pages = journalVM.Pages;
            WineDataDomain.JournalPage currentPage = null;

            foreach(WineDataDomain.JournalPage p in pages)
            {
                if (p.PageNumber == book.SelectedFrontIndex)
                {
                    currentPage = p;
                }
            }

            if (currentPage != null)
            {
                Messenger.Default.Send<WineDataDomain.JournalPage>(currentPage, "To_MainWindow_WinePresenter");
            }
            else
            {
                MessageBox.Show("Internal Error: Page Matching failed");
            }
        }


    }
}