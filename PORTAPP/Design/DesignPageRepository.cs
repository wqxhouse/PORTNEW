using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System;
using ActiproSoftware.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace PORTAPP.Design
{
    
    public class DesignPageRepository : WineDataDomain.IJournalPageRepository
    {
        /// <summary>
        /// Initializes a new instance of the DesignPageRepository class.
        /// </summary>
        public DesignPageRepository()
        {

        }

        public void GetUserPages(string username, Action<IEnumerable<WineDataDomain.JournalPage>, Exception> callback)
        {
            var pageCollection =
                new DeferrableObservableCollection<WineDataDomain.JournalPage>();

            pageCollection.Add(new WineDataDomain.JournalPage()
            {
                OverlayTopLeftColor = Color.FromArgb(102, 85, 50, 50),
                OverlayBottomRightColor = Color.FromArgb(102, 255, 50, 50),
                Header = "Travel in Italy",
                ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/001.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
                Text = "Need to get away? Want to see the world?\n\n    Italy is the perfect place for your next family vacation. Experience beautiful sights, taste delightful Italian cuisine, and see what Europe has to offer you!",
                PageNumber = 0
            });


            pageCollection.Add(new WineDataDomain.JournalPage()
            {
                OverlayTopLeftColor = Color.FromArgb(102, 142, 64, 64),
                OverlayBottomRightColor = Color.FromArgb(102, 113, 255, 255),
                Header = "Sightseeing",
                ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/002.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
                Text = "A few must-see places include:\n\n - Venice\n - Bologna\n - Florence\n - Rome\n - Naples\n - Palermo\n - Pisa\n - Siena",
                PageNumber = 1
            
            });


            pageCollection.Add(new WineDataDomain.JournalPage()
            {
                OverlayTopLeftColor = Color.FromArgb(102, 108, 132, 60),
                OverlayBottomRightColor = Color.FromArgb(102, 208, 255, 113),
                Header = "Cuisine",
                ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/003.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },              
                Text = "Italy is famous for its pasta, pizza, and gelato.\n\n    While you have probably had these foods before, there is nothing like fresh Italian pasta, pizza, or gelato. Get your taste buds ready because they are in for a treat.",
                PageNumber = 2
            });


            pageCollection.Add(new WineDataDomain.JournalPage()
            {
                OverlayTopLeftColor = Color.FromArgb(102, 142, 64, 64),
                OverlayBottomRightColor = Color.FromArgb(102, 113, 255, 255),
                Header = "Getting Around",
                ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/004.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
                Text = "    While it is possible to get around Italy without a car, it can sometimes be difficult. Especially if you are traveling with your family, a car can sometimes be mandatory. If you are feeling adventurous, however, the Eurail system and the Italian buses are capable.",
                PageNumber = 3
            });


            callback(pageCollection, null);
        }


        public void GetUserJournalCollection(string username, Action<IEnumerable<WineDataDomain.Journal>, Exception> callback)
        {
            var collection =
                new DeferrableObservableCollection<WineDataDomain.Journal>
                {
                    new WineDataDomain.Journal
                    {
                        JournalID = 0,
                        Text = "Hello World",
                        Title = "Test Page", 
                        Date = DateTime.Now
                    },

                    new WineDataDomain.Journal
                    {
                        JournalID = 1,
                        Text = "I am Wqxhouse",
                        Title = "Zonglin Wu",
                        Date = DateTime.Now
                    },

                    new WineDataDomain.Journal
                    {
                        JournalID = 2,
                        Text = "Author is #2 Test",
                        Title = "Test 2 Data",
                        Date = DateTime.Now
                    }

                };

            callback(collection, null);

        }
    }
}