using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows;
using System.Collections.Generic;

namespace PORTAPP.Recommendation
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class RecommendationMainVM : ViewModelBase, IPageViewModel
    {

        private readonly WineDataDomain.IWineRepository _wineRepo;

        /// <summary>
        /// Initializes a new instance of the RecommendationMainVM class.
        /// </summary>
        public RecommendationMainVM(WineDataDomain.IWineRepository wineRepo)
        {
            _wineRepo = wineRepo;

            populateRecWines();
        }

        private void populateRecWines()
        {
            if (RecItems == null)
            {
                RecItems = new ObservableCollection<RecWines>();
            }

            //recommend by ratings decending
            _wineRepo.GetWinesByRatingsDecending(
                (w, e) =>
                {
                    if (e != null)
                    {
                        MessageBox.Show(e.Message);
                    }
                    else
                    {

                        var domainList = new List<WineDataDomain.Wine>(w);

                        foreach (WineDataDomain.Wine domainWine in domainList)
                        {
                            var recWine = RecWines.DomainToRec(domainWine);

                            RecItems.Add(recWine);
                        }
                    }
                });
        }


        /// <summary>
        /// The <see cref="RecItems" /> property's name.
        /// </summary>
        public const string RecItemsPropertyName = "RecItems";

        private ObservableCollection<RecWines> _recItems;

        /// <summary>
        /// Sets and gets the RecItems property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<RecWines> RecItems
        {
            get
            {
                return _recItems;
            }

            set
            {
                if (_recItems == value)
                {
                    return;
                }
           
                _recItems = value;
                RaisePropertyChanged(RecItemsPropertyName);
            }
        }

        public string Name
        {
            get { return "Recommendations"; }
        }
    }
}