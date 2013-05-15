using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;
using System;
using System.Threading;
using System.Windows.Input;

namespace PORTAPP
{
    /// <summary>
    /// Description for MainWindow.
    /// </summary>
    public partial class MainWindow : Window
    {

        private ViewModel.MainViewModel mainVM;
        BackgroundWorker worker;

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            mainVM = (ViewModel.MainViewModel)DataContext;

            Messenger.Default.Register<PropertyChangedMessage<IPageViewModel>>(this, InitViews);
                

        }

        private void InitViews(PropertyChangedMessage<IPageViewModel> msg){
            var vm = msg.NewValue;

            if (vm is WineCellar.WineCellarVM)
            {
                worker.DoWork += (s, e) => 
                {   
                    mainVM.IsBusy = true;
                    mainVM.BusyContent = "Loading WineCellar";
                    var view = new WineCellar.WineCellar(); 
                    presenter.Content = mainVM.CurrentPageViewModel;
                        
                };
                worker.RunWorkerCompleted += (s, e) => { mainVM.IsBusy = false; };

                worker.RunWorkerAsync();
            }
            else if (vm is WineCellar.WineRackVM)
            {
                worker.DoWork += (s, e) =>
                {
                    mainVM.IsBusy = true;
                    mainVM.BusyContent = "Loading WineCellar";
                    presenter.Content = new WineCellar.WineRack();
                };
                worker.RunWorkerCompleted += (s, e) => { mainVM.IsBusy = false; };

                worker.RunWorkerAsync();
            }
            else if (vm is WineJournal.WineJournalVM)
            {
                //var view = new WineJournal.WineJournal();
                //worker.DoWork += (s, e) =>
                //{
                //    try
                //    {
                        
                //        mainVM.IsBusy = true;
                //        mainVM.BusyContent = "Loading WineJournal";
                //        var view = new WineJournal.WineJournal();
                //        //presenter.Content = mainVM.CurrentPageViewModel;
                //        System.Windows.Threading.Dispatcher.Run();
                //        presenter.Dispatcher.BeginInvoke((Action<WineJournal.WineJournal>)((ss) => { presenter.Content = ss; }), new WineJournal.WineJournal());
                //        // MessageBox.Show("hh");
                //    }
                //    catch (Exception ex)
                //    {
                //    }
                //};
                //worker.RunWorkerCompleted += (s, e) => { mainVM.IsBusy = false; };

                //worker.RunWorkerAsync();
                //Thread thread = new Thread(() =>
                //    {
                //        new WineJournal.WineJournal();
                //        presenter.Dispatcher.BeginInvoke((Action<WineJournal.WineJournal>)((ss) => { presenter.Content = ss; }), new WineJournal.WineJournal());
                //        System.Windows.Threading.Dispatcher.Run();
                //    });
                //thread.SetApartmentState(ApartmentState.STA);
                //thread.Start();
                Mouse.OverrideCursor = Cursors.Wait;
                try
                {
                     presenter.Content = new WineJournal.WineJournal();
                }
                finally
                {
                    Mouse.OverrideCursor = null;
                }
               

               
                //mainVM.IsBusy = false;



                //presenter.Content = new WineJournal.WineJournal(); 


            }
            else if (vm is CommentBoard.CommentBoardVM)
            {
                worker.DoWork += (s, e) =>
                {
                    mainVM.IsBusy = true;
                    mainVM.BusyContent = "Loading CommentBoard";
                    presenter.Content = new CommentBoard.CommentBoard();
                };
                worker.RunWorkerCompleted += (s, e) => { mainVM.IsBusy = false; };

                worker.RunWorkerAsync();
            }

            
        }


    }
}