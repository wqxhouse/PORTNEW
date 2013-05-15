using GalaSoft.MvvmLight;

namespace PORTAPP.WineCellar
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class WineCellarVM : ViewModelBase, IPageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the WineCellarVM class.
        /// </summary>
        public WineCellarVM()
        {
        }

        public string Name
        {
            get { return "WineCellar"; }
        }
    }
}