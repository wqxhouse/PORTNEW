using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PORTAPP.Design
{
    public class DesignWineRepository :WineDataDomain.IWineRepository
    {
        public void GetAllWine(Action<IEnumerable<WineDataDomain.Wine>, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void GetWineTypeCatagory(Action<IEnumerable<WineDataDomain.Refinement>, Exception> callback)
        {
            var wineTypes = new List<WineDataDomain.Refinement>
            {
                new WineDataDomain.Refinement{Id = 0, Name = "Red Wine", Url = "wqxhouse.com"},
                new WineDataDomain.Refinement{Id = 1, Name = "White Wine", Url = "wqxhouse.com"},
                new WineDataDomain.Refinement{Id = 2, Name = "Sake", Url = "wqxhouse.com"}
            };

            callback(wineTypes, null);
        }

        public void GetWineVarietalsCatagory(Action<IEnumerable<WineDataDomain.Refinement>, Exception> callback)
        {
            var varietalTypes = new List<WineDataDomain.Refinement>
            {
                new WineDataDomain.Refinement{Id = 0, Name = "GrapeTest", Url = "wqxhouse.com"},
                new WineDataDomain.Refinement{Id = 1, Name = "Gary Grape", Url = "wqxhouse.com"},
                new WineDataDomain.Refinement{Id = 2, Name = "Super Grape", Url = "wqxhouse.com"},
                new WineDataDomain.Refinement{Id = 3, Name = "Joe Grape", Url = "wqxhouse.com"},
                new WineDataDomain.Refinement{Id = 4, Name = "Wqx Grape", Url = "wqxhouse.com"},
                new WineDataDomain.Refinement{Id = 5, Name = "Eddie Grape", Url = "wqxhouse.com"},
                new WineDataDomain.Refinement{Id = 6, Name = "Wen Grape", Url = "wqxhouse.com"},
                new WineDataDomain.Refinement{Id = 7, Name = "Austin Grape", Url = "wqxhouse.com"},
                new WineDataDomain.Refinement{Id = 8, Name = "Leeann Grape", Url = "wqxhouse.com"}
            };

            callback(varietalTypes, null);
        }

        public void GetWineVarietalsCatagoryByWineType(string wineType, Action<IEnumerable<WineDataDomain.Refinement>, Exception> callback)
        {
            List<WineDataDomain.Refinement> wineCatagory = null;
            GetWineTypeCatagory((c, e) => { wineCatagory = new List<WineDataDomain.Refinement>(c); });

            List<WineDataDomain.Refinement> varietalCatagory = null;
            GetWineVarietalsCatagory((v, e) => { varietalCatagory = new List<WineDataDomain.Refinement>(v); });

            if (wineCatagory != null)
            {
                var query = from wt in wineCatagory
                            where wt.Name == wineType
                            select wt.Id;

                
                switch (query.FirstOrDefault())
                {
                    case 0:
                        var varitals0 = from v in varietalCatagory
                                       where v.Id == 0 || v.Id == 1 || v.Id == 2
                                       select v;
                        callback(varitals0, null);
                        return;

                        //break;
                    case 1:

                        var varitals1 = from v in varietalCatagory
                                       where v.Id == 3 || v.Id == 4 || v.Id == 5
                                       select v;
                        callback(varitals1, null);
                        return;

                    case 2:

                        var varitals2 = from v in varietalCatagory
                                       where v.Id == 6 || v.Id == 7 || v.Id == 8
                                       select v;
                        callback(varitals2, null);
                        return;
                }

                callback(null, new Exception("No internal matching"));
            }
        }


        public void GetWineRegionCatagory(Action<IEnumerable<WineDataDomain.Refinement>, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void GetWineCountryCatagory(Action<IEnumerable<WineDataDomain.Refinement>, Exception> callback)
        {
            throw new NotImplementedException();
        }
    }
}
