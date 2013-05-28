using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WineDataDomain
{
    public interface IWineRepository
    {
        //TODO:
        void GetAllWine(Action<IEnumerable<WineDataDomain.Wine>, Exception> callback);
        void GetWinesByRatingsDecending(Action<IEnumerable<WineDataDomain.Wine>, Exception> callback);
        
        //Catagory part
        void GetWineTypeCatagory(Action<IEnumerable<WineDataDomain.Refinement>, Exception> callback);
        void GetWineVarietalsCatagory(Action<IEnumerable<WineDataDomain.Refinement>, Exception> callback);
        void GetWineRegionCatagory(Action<IEnumerable<WineDataDomain.Refinement>, Exception> callback);
        void GetWineCountryCatagory(Action<IEnumerable<WineDataDomain.Refinement>, Exception> callback);

        void GetWineVarietalsCatagoryByWineType(string wineType, Action<IEnumerable<WineDataDomain.Refinement>, Exception> callback);

       

    }
}
