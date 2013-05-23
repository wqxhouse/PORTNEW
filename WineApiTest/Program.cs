using System;
using WineApi;

namespace WineApiExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Config.ApiKey = "c861359b839d9e285224c7d5f0d24f3c";
                CatalogService catalogService = new CatalogService();
                Catalog catalog = catalogService
                    .State("CA")
                    .InStock(true)
                    .Search("Merlot")
                    .RatingFilter(90, 96)
                    .SortBy(SortOptions.Rating, SortDirection.Descending)
                    .Execute();
                Console.WriteLine("Number of products found: {0}", catalog.Products.Total);
                foreach (Product p in catalog.Products.List)
                {
                    Console.WriteLine(p.Name);
                }
            }
            catch (WineApiException ex)
            {
                Console.Error.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Console.Error.WriteLine(ex.InnerException.Message);
                }
            }
        }
    }
}