using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PORTAPP.UserSystem
{
    public class Preference
    {
        private string varietal_name = String.Empty;
        private Uri wineType_iconPath;
        private string iconBackground = String.Empty;

        private int _wineTypeID;

        public Preference(int wineTypeID, WineDataDomain.Refinement varietal)
        {
            _wineTypeID = wineTypeID;
            assignIconPath(_wineTypeID);

            VarietalName = varietal.Name;

        }

        private void assignIconPath(int wineTypeID)
        {
            switch (wineTypeID)
            {
                    //TODO: Learn Uri relative
                    //Cautious: 26*26 size or force conversion -> slow
                case 0:
                    wineType_iconPath = new Uri("C:\\Users\\Wqxhouse\\Documents\\GitHub\\PORTNEW\\PORTAPP\\UserSystem\\PreferenceIcons\\RedWine_2.png", UriKind.Absolute);
                    break;
                case 1:
                    wineType_iconPath = new Uri("C:\\Users\\Wqxhouse\\Documents\\GitHub\\PORTNEW\\PORTAPP\\UserSystem\\PreferenceIcons\\WhiteWine_2.png", UriKind.Absolute);
                    break;
                case 2:
                    wineType_iconPath = new Uri("C:\\Users\\Wqxhouse\\Documents\\GitHub\\PORTNEW\\PORTAPP\\UserSystem\\PreferenceIcons\\RoseWine_2.png", UriKind.Absolute);
                    break;
                case 3:
                    wineType_iconPath = new Uri("/PreferenceIcons/ChampagneWine.png", UriKind.RelativeOrAbsolute);
                    break;
                case 4:
                    wineType_iconPath = new Uri("/PreferenceIcons/SakeWine.png", UriKind.RelativeOrAbsolute);
                    break;
                case 5:
                    wineType_iconPath = new Uri("/PreferenceIcons/DessertWine.png", UriKind.RelativeOrAbsolute);
                    break;

            }

            
        }

        public string VarietalName
        {
            get
            {
                return this.varietal_name;
            }
            set
            {
                if (this.varietal_name != value)
                {
                    this.varietal_name = value;
                }
            }
        }

        public Uri WineType_IconPath
        {
            get
            {
                return this.wineType_iconPath;
            }
            set
            {
                if (this.wineType_iconPath != value)
                {
                    this.wineType_iconPath = value;
                }
            }
        }

        public string IconBackground
        {
            get
            {
                return this.iconBackground;
            }
            set
            {
                if (this.iconBackground != value)
                {
                    this.iconBackground = value;
                }
            }
        }
    }
}
