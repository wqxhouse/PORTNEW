using GalaSoft.MvvmLight;

namespace PORTAPP.SearchEngine
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SearchPageVM : ViewModelBase
    {
        private readonly WineDataDomain.IWineRepository _wineRepo;


        /// <summary>
        /// Initializes a new instance of the SearchPageVM class.
        /// </summary>
        public SearchPageVM(WineDataDomain.IWineRepository wineRepo)
        {
            _wineRepo = wineRepo;

        }
    }
}