using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Windows;
using System;

namespace PORTAPP.WineCatagory
{

    public class WineCatagoryHandler
    {
        private readonly WineDataDomain.IWineRepository _repo;

        private Dictionary<int, WineDataDomain.Refinement[]> _wineTypesToVarietals =
                new Dictionary<int, WineDataDomain.Refinement[]>();

        private IEnumerable<WineDataDomain.Refinement> _wineTypes;
        private IEnumerable<WineDataDomain.Refinement> _varietals;
        private IEnumerable<WineDataDomain.Refinement> _regions;

        #region property

        public IEnumerable<WineDataDomain.Refinement> WineTypes
        {
            get
            {
                return _wineTypes;
            }
            set
            {
                if (value == _wineTypes)
                {
                    return;
                }

                _wineTypes = value;
            }
        }

        public IEnumerable<WineDataDomain.Refinement> Varietals
        {
            get
            {
                return _varietals;
            }
            set
            {
                if (value == _varietals)
                {
                    return;
                }

                _varietals = value;
            }
        }

        public IEnumerable<WineDataDomain.Refinement> Regions
        {
            get
            {
                return _regions;
            }
            set
            {
                if (value == _regions)
                {
                    return;
                }

                _regions = value;
            }
        }

       
        #endregion
        

        /// <summary>
        /// Initializes a new instance of the WineCatagoryHandler class.
        /// </summary>
        public WineCatagoryHandler(WineDataDomain.IWineRepository repo)
        {
            _repo = repo;

        }

        private void getWineTypes()
        {
            _repo.GetWineTypeCatagory(
                  (types, e) =>
                  {
                      if (e != null)
                      {
                          MessageBox.Show("CatagoryHandler: " + e.Message);
                          throw e;
                      }
                      else
                      {
                          WineTypes = new List<WineDataDomain.Refinement>(types);
                      }
                  });

        }

        private void getWineVarietals()
        {
            _repo.GetWineVarietalsCatagory(
               (var, e) =>
               {
                   if (e != null)
                   {
                       MessageBox.Show("CatagoryHandler: " + e.Message);
                       throw e;
                   }
                   else
                   {
                       Varietals = new List<WineDataDomain.Refinement>(var);
                   }
               });
        }

        private void getWineRegion()
        {
            _repo.GetWineRegionCatagory(
               (reg, e) =>
               {
                   if (e != null)
                   {
                       MessageBox.Show("CatagoryHandler: " + e.Message);
                       throw e;
                   }
                   else
                   {
                       Regions = new List<WineDataDomain.Refinement>(reg);
                   }
               });
        }



        public Dictionary<int, WineDataDomain.Refinement[]>
            GetWineTypeToVarietals()
        {
            //initialize
            this.getWineTypes();
            this.getWineVarietals();


            //execute
            if (_wineTypes != null && _varietals != null)
            {
                foreach (var wineType in _wineTypes)
                {
                    string wineTypeName = wineType.Name;
                    int wineTypeId = wineType.Id;

                    List<WineDataDomain.Refinement> linkedVarietals = null;
                    _repo.GetWineVarietalsCatagoryByWineType
                        (wineType.Name,
                        (v, e) =>
                        {
                            if (e != null)
                            {
                                MessageBox.Show(e.Message);
                            }
                            else
                            {
                                linkedVarietals = new List<WineDataDomain.Refinement>(v);
                            }
                        });


                    _wineTypesToVarietals.Add(wineTypeId, linkedVarietals.ToArray());

                }
            }

            return _wineTypesToVarietals;
        }


    }
}