using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PORTAPP.Recommendation
{
    public class RecWines
    {
        public string WineName { get; set; }
        public string WineType { get; set; }
        public string WineType_Icon { get; set; }
        public string WineVarietal { get; set; }
        public string WinePicLarge { get; set; }
        public string WinePicSmall { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public string BackGroundImg { get; set; }
        public double Price { get; set; }

        public static RecWines DomainToRec(WineDataDomain.Wine wine)
        {
            return new RecWines
            {
                WineName = wine.WineName,
                WineType = wine.WineType,
                WineVarietal = wine.WineVarietal,
                WinePicLarge = wine.WinePicLarge,
                WinePicSmall = wine.WinePicSmall,
                Rating = wine.Rating,
                Description = wine.Description,
                Price = wine.Price
            };
        }

        

    }

}
