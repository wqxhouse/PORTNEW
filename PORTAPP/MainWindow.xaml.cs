using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;
using System;
using System.Threading;
using System.Windows.Input;
using System.Windows.Media;
using VisualTargetDemo;
using System.Windows.Controls;

namespace PORTAPP
{
    /// <summary>
    /// Description for MainWindow.
    /// </summary>
    public partial class MainWindow : Window
    {

        private ViewModel.MainViewModel mainVM;
        private BusyIndicator.BusyClass busyVM;

        private static AutoResetEvent s_event = new AutoResetEvent(false);


        Cursor cur;

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            #region Cursor Handling
            CursorConverter cc = new CursorConverter();
            cur = cc.ConvertFromString(@"C:\Users\Wqxhouse\Documents\GitHub\PORTNEW\PORTAPP\Resources\Cursor\Thor-normal.cur") as Cursor;
            if (cur != null)
            {
                Mouse.OverrideCursor = cur;
            } 
            #endregion


            InitializeComponent();

            mainVM = (ViewModel.MainViewModel)DataContext;

            busyVM = new BusyIndicator.BusyClass();
            busyIndicator.Child = InitIndicatorThread();

            
            Messenger.Default.Register<PropertyChangedMessage<IPageViewModel>>(this, changeViews);


            #region Subscribe and Process JournalEditing
            Messenger.Default.Register<WineDataDomain.JournalPage>(this, "To_MainWindow_WinePresenter",
                (journalPage) =>
                {

                    //redirect the page number to JournalEditor
                    Messenger.Default.Send<WineDataDomain.JournalPage>(journalPage, "ToJournalEditorVM_journalPage");

                    //attach presenter
                    busyVM.IsBusy = true;
                    busyVM.BusyContent = "Loading JournalEditor";
                    presenter.Content = new WineJournal.JournalEditor();
                    busyVM.IsBusy = false;
                });


            #endregion


            //initialize start page
            initViews();
        }

        //multithread for UI
        private HostVisual InitIndicatorThread()
        {
            HostVisual hostVisual = new HostVisual();

            Thread thread = new Thread(new ParameterizedThreadStart(IndicatorThread));
            thread.ApartmentState = ApartmentState.STA;
            thread.IsBackground = true;
            thread.Start(hostVisual);

            s_event.WaitOne();

            return hostVisual;
        }

        private void IndicatorThread(object arg)
        {

            HostVisual hostVisual = (HostVisual)arg;
            VisualTargetPresentationSource visualTargetPS = new VisualTargetPresentationSource(hostVisual);
            s_event.Set();

            visualTargetPS.RootVisual = CreateIndicatorElement();
            System.Windows.Threading.Dispatcher.Run();
        }

        private FrameworkElement CreateIndicatorElement()
        {
            
            BusyIndicator.BusyView bv = new BusyIndicator.BusyView(busyVM);
            bv.BeginInit();
            bv.EndInit();
            return bv;
           
        }


        private void initViews()
        {
            busyVM.IsBusy = true;
            busyVM.BusyContent = "Loading Recommendations";

            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                presenter.Content = new Recommendation.RecommendationMain();
            }
            finally
            {
                Mouse.OverrideCursor = cur;
            }
            busyVM.IsBusy = false;
        }

        private void changeViews(PropertyChangedMessage<IPageViewModel> msg)
        {
            var vm = msg.NewValue;

            if (vm is Recommendation.RecommendationMainVM)
            {

                busyVM.IsBusy = true;
                busyVM.BusyContent = "Loading Recommendations";

                Mouse.OverrideCursor = Cursors.Wait;
                try
                {
                    presenter.Content = new Recommendation.RecommendationMain();
                }
                finally
                {
                    Mouse.OverrideCursor = cur;
                }
                busyVM.IsBusy = false;
            }
            else if (vm is WineCellar.WineRackVM)
            {

                busyVM.IsBusy = true;
                busyVM.BusyContent = "Loading WineCellar";

                Mouse.OverrideCursor = Cursors.Wait;
                try
                {
                    presenter.Content = new WineCellar.WineRack();
                    
                    
                }
                finally
                {
                    Mouse.OverrideCursor = cur;
                }

                busyVM.IsBusy = false;

            }
            else if (vm is WineJournal.WineJournalVM)
            {


                busyVM.IsBusy = true;
                busyVM.BusyContent = "Loading WineJournal";

                Mouse.OverrideCursor = Cursors.Wait;
                try
                {
                    presenter.Content = new WineJournal.WineJournal();
                }
                finally
                {
                    Mouse.OverrideCursor = cur;
                }

                busyVM.IsBusy = false;

            }
            else if (vm is CommentBoard.CommentBoardVM)
            {
                busyVM.IsBusy = true;
                busyVM.BusyContent = "Loading CommentBoard";

                Mouse.OverrideCursor = Cursors.Wait;
                try
                {
                    presenter.Content = new CommentBoard.CommentBoard();
                }
                finally
                {
                    Mouse.OverrideCursor = cur;
                }

                busyVM.IsBusy = false;

            }


        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


    }
}