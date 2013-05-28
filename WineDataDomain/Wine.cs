using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WineDataDomain
{
    public class Wine
    {
        //TODO: fill the rest of field
        public string WineName { get; set; }
        public string WineType { get; set; }
       
        public string WineVarietal { get; set; }

        public string WinePicLarge { get; set; }
        public string WinePicMedium { get; set; }
        public string WinePicSmall { get; set; }

        public int Rating { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }
    }
}
