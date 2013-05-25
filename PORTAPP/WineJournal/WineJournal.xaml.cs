using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System;
using System.Windows.Media;

namespace PORTAPP.WineJournal
{
    /// <summary>
    /// Description for WineJournal.
    /// </summary>
    public partial class WineJournal
    {

        private WineJournalVM journalVM;

        //private int backTextHeight;
        //private int backTextWidth;
        //private int frontTextHeight;
        //private int frontTextWidth;
        
        /// <summary>
        /// Initializes a new instance of the WineJournal class.
        /// </summary>
        public WineJournal()
        {
            InitializeComponent();
            journalVM = (WineJournalVM)DataContext;

            
            
        }


        private void setVMPageProperity(int pageHeight, int pageWidth, int fontHeight, int fontWidth)
        {
            journalVM.PageSettings =
                new PageProperty
                {
                    PageHeight = pageHeight,
                    PageWidth = pageWidth,
                    TextHeight = fontHeight,
                    TextWidth = fontWidth
                };
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


        //bug loaded two times
        private void Grid_LoadedBack(object sender, RoutedEventArgs e)
        {
            Grid backPageGrid = (Grid)sender;
            var childCollection = backPageGrid.Children;
            ContentPresenter p = null;

            foreach (UIElement u in childCollection)
            {
                if (Grid.GetRow(u) == 1)
                {
                    p = (ContentPresenter)u;
                }
            }

            int backTextHeight = (int)(p.ActualHeight);
            int backTextWidth = (int)(p.ActualWidth);

            MessageBox.Show(backTextHeight.ToString() + " " + backTextWidth.ToString());

            FontFamily fontFamily = new FontFamily("Georgia");
            double fontDpiSize = 16;
            double fontHeight = Math.Ceiling(fontDpiSize * fontFamily.LineSpacing);
            double fontWidth = MeasureTextWidth("G", 16, "Georgia");
            MessageBox.Show(backTextHeight + " " +  backTextWidth + " " + (int)fontHeight + " " + (int)fontWidth);
            setVMPageProperity(backTextHeight, backTextWidth, (int)fontHeight, (int)fontWidth);

            //Messenger.Default.Send<string>
            //    ("settingsReady",
            //    "FromWineJournal_ToWIneJournalVM_settingsReady");
        }

        
        //Width measure Helper
        private double MeasureTextWidth(string text, double fontSize, string fontFamily)
        {
            FormattedText formattedText = new FormattedText(
                text,
                System.Globalization.CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                new Typeface(fontFamily.ToString()),
                fontSize,
                Brushes.Black
            );
            return formattedText.WidthIncludingTrailingWhitespace;
        } 


    }
}