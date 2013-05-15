using System.Windows;



namespace PORTAPP.WineJournal
{
    /// <summary>
    /// Description for WineJournal.
    /// </summary>
    public partial class WineJournal
    {
       
        /// <summary>
        /// Initializes a new instance of the WineJournal class.
        /// </summary>
        public WineJournal()
        {
            InitializeComponent();

          

        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("Hacked!");
        }


    }
}