using GalaSoft.MvvmLight.Threading;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Input;

namespace PORTAPP
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            //Handle splash screen
            #region Splash screen
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Loaded,
                    (DispatcherOperationCallback)delegate { CloseSplashScreen(); return null; },
                    this);
            base.OnStartup(e); 
            #endregion

            #region Cursor
            CursorConverter cc = new CursorConverter();
            Cursor cur = cc.ConvertFromString(@"C:\Users\Wqxhouse\Documents\GitHub\PORTNEW\PORTAPP\Resources\Cursor\Thor-normal.cur") as Cursor;
            if(cur != null)
            {
                Mouse.OverrideCursor = cur;
            }

            #endregion
        }

        private void CloseSplashScreen()
        {
            // signal the native process (that launched us) to close the splash screen
            using (var closeSplashEvent = new EventWaitHandle(false,
                EventResetMode.ManualReset, "CloseSplashScreenEventSplashScreenStarter"))
            {
                closeSplashEvent.Set();
            }
        }
    }
}
