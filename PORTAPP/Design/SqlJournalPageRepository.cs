using System.Collections.Generic;
using System;
using ActiproSoftware.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Linq;
using System.Windows;

namespace PORTAPP.Design
{
    
    public class SqlJournalPageRepository : WineDataDomain.IJournalPageRepository
    {

        public void Separation(string text, int tWidth, int tHeight, int wWidth, int wHeight,
                                string username, 
                                Action<IEnumerable<WineDataDomain.JournalPage>, Exception> callback)
        {
            var pageCollection = new DeferrableObservableCollection<WineDataDomain.JournalPage>();
            int widNum = tWidth / wWidth;
            int HHeight = tHeight / wHeight;
            int total = text.Length;

            int complement = 0;
            int count = 0;

            string txt = "";
            string temp = "";

            int LCount = 0;
            int WCount = 0;
            int pageNumber = 0;

            while (count < total)
            {
                while (WCount < widNum)
                {
                    if (count == total)
                    {
                        txt += temp;
                        pageNumber++;
                        pageCollection.Add(new WineDataDomain.JournalPage()
                        {
                            OverlayTopLeftColor = Color.FromArgb(102, 108, 132, 60),
                            OverlayBottomRightColor = Color.FromArgb(102, 208, 255, 113),
                            Header = "Cuisine",
                            ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/003.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
                            Text = txt,
                            PageNumber = pageNumber
                        });
                        return;
                    }
                    else if (text[count] == ' ')
                    {
                        txt += temp;
                        txt += ' ';
                        complement = 0;
                        temp = "";
                        count++;
                        WCount++;
                    }

                    else if ((int)text[count] == 13)
                    {
                        txt += temp;
                        temp = "";
                        complement = 0;
                        txt += (char)(13);
                        txt += (char)(10);
                        count = count + 2;
                        WCount = 0;
                        LCount++;
           
                    }

                    else
                    {
                        complement++;
                        temp += text[count];
                        count++;
                        WCount++;
                    }
                }
                if (text[count] == ' ')
                {
                    txt += temp;
                    complement = 0;
                    temp = "";

                }
                if (complement != 0)
                {
                    while (complement > 0)
                    {
                        txt += '@';
                        complement--;
                    }
                }
                LCount++;
                //Console.WriteLine(txt);
                //txt = "";
                if (LCount == HHeight)
                {
                    // create a new page
                    pageNumber++;
                    pageCollection.Add(new WineDataDomain.JournalPage()
                    {
                        OverlayTopLeftColor = Color.FromArgb(102, 108, 132, 60),
                        OverlayBottomRightColor = Color.FromArgb(102, 208, 255, 113),
                        Header = "Cuisine",
                        ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/003.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
                        Text = txt,
                        PageNumber = pageNumber
                    });
                    txt = "";
                }
                txt ="";
                if (temp.Length != 0)
                {
                    WCount = temp.Length;
                }
                else
                {
                    WCount = 0;
                }
            }
            txt += temp;
            pageNumber ++;
            pageCollection.Add(new WineDataDomain.JournalPage()
            {
                OverlayTopLeftColor = Color.FromArgb(102, 108, 132, 60),
                OverlayBottomRightColor = Color.FromArgb(102, 208, 255, 113),
                Header = "Cuisine",
                ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/003.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
                Text = txt,
                PageNumber = pageNumber
            });
            return;
        }



        public void GetUserPages(int tWidth, int tHeight, int wWidth, int wHeight, string username, System.Action<System.Collections.Generic.IEnumerable<WineDataDomain.JournalPage>, System.Exception> callback)
        {
            /*
            string text = "Assignment 2C\nMain Claim:\nBorrowing ideas from works of others is permissible if the borrowed ideas are used as bases of creative works with new ideas with the source appropriately cited. ";
           // Idea borrowers need to ask the authors of original works for permission to cite a large portion of the works; small portion of content, however, can be cited directly without permission. However, omitting citation is not permissible and is considered as plagiarism.";
            var pageCollection = new DeferrableObservableCollection<WineDataDomain.JournalPage>();
            int widNum = tWidth / wWidth;
            int HHeight = tHeight / wHeight;
            int total = text.Length;

            int complement = 0;
            int count = 0;

            string txt = "";
            string temp = "";

            int LCount = 0;
            int WCount = 0;
            int pageNumber = 0;

            while (count < total)
            {
                while (WCount < widNum)
                {
                    if (count == total)
                    {
                        txt += temp;
                        pageNumber++;
                        pageCollection.Add(new WineDataDomain.JournalPage()
                        {
                            OverlayTopLeftColor = Color.FromArgb(102, 108, 132, 60),
                            OverlayBottomRightColor = Color.FromArgb(102, 208, 255, 113),
                            Header = "Cuisine",
                            ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/003.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
                            Text = txt,
                            PageNumber = pageNumber
                        });

                        //return;
                        callback(pageCollection, null);
                        return;
                    }
                    else if (text[count] == ' ')
                    {
                        txt += temp;
                        txt += ' ';
                        complement = 0;
                        temp = "";
                        count++;
                        WCount++;
                    }

                    else if ((int)text[count] == 13)
                    {
                        txt += temp;
                        temp = "";
                        complement = 0;
                        txt += (char)(13);
                        txt += (char)(10);
                        count = count + 2;
                        WCount = 0;
                        LCount++;

                    }

                    else
                    {
                        complement++;
                        temp += text[count];
                        count++;
                        WCount++;
                    }
                }
                if (text[count] == ' ')
                {
                    txt += temp;
                    complement = 0;
                    temp = "";

                }
                if (complement != 0)
                {
                    while (complement > 0)
                    {
                        txt += '@';
                        complement--;
                    }
                }
                LCount++;
                //Console.WriteLine(txt);
                //txt = "";
                if (LCount == HHeight)
                {
                    // create a new page
                    pageNumber++;
                    pageCollection.Add(new WineDataDomain.JournalPage()
                    {
                        OverlayTopLeftColor = Color.FromArgb(102, 108, 132, 60),
                        OverlayBottomRightColor = Color.FromArgb(102, 208, 255, 113),
                        Header = "Cuisine",
                        ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/003.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
                        Text = txt,
                        PageNumber = pageNumber
                    });
                    txt = "";
                }
                txt = "";
                if (temp.Length != 0)
                {
                    WCount = temp.Length;
                }
                else
                {
                    WCount = 0;
                }
            }
            txt += temp;
            pageNumber++;
            pageCollection.Add(new WineDataDomain.JournalPage()
            {
                OverlayTopLeftColor = Color.FromArgb(102, 108, 132, 60),
                OverlayBottomRightColor = Color.FromArgb(102, 208, 255, 113),
                Header = "Cuisine",
                ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/003.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
                Text = txt,
                PageNumber = pageNumber
            });


           // return;
            */


            
            var pageCollection = new DeferrableObservableCollection<WineDataDomain.JournalPage>();
             
            pageCollection.Add(new WineDataDomain.JournalPage()
            {
                OverlayTopLeftColor = Color.FromArgb(102, 85, 50, 50),
                OverlayBottomRightColor = Color.FromArgb(102, 255, 50, 50),
                Header = "Travel in Italy",
                ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/001.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
                Text = "Need to get away? Want to see the world?\n\n    Italy is the perfect place for your next family vacation. Experience beautiful sights, taste delightful Italian cuisine, and see what Europe has to offer you!"
           ,
                PageNumber = 0 
            });


            pageCollection.Add(new WineDataDomain.JournalPage()
            {
                OverlayTopLeftColor = Color.FromArgb(102, 142, 64, 64),
                OverlayBottomRightColor = Color.FromArgb(102, 113, 255, 255),
                Header = "Sightseeing",
                ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/002.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
                Text = "A few must-see places include:\n\n - Venice\n - Bologna\n - Florence\n - Rome\n - Naples\n - Palermo\n - Pisa\n - Siena"
            ,
                PageNumber = 1
            });


            pageCollection.Add(new WineDataDomain.JournalPage()
            {
                OverlayTopLeftColor = Color.FromArgb(102, 108, 132, 60),
                OverlayBottomRightColor = Color.FromArgb(102, 208, 255, 113),
                Header = "Cuisine",
                ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/003.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
                Text = "Italy is famous for its pasta, pizza, and gelato.\n\n    While you have probably had these foods before, there is nothing like fresh Italian pasta, pizza, or gelato. Get your taste buds ready because they are in for a treat."
            ,
                PageNumber = 2
            });


            pageCollection.Add(new WineDataDomain.JournalPage()
            {
                OverlayTopLeftColor = Color.FromArgb(102, 142, 64, 64),
                OverlayBottomRightColor = Color.FromArgb(102, 113, 255, 255),
                Header = "Getting Around",
                ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/004.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
                Text = "    While it is possible to get around Italy without a car, it can sometimes be difficult. Especially if you are traveling with your family, a car can sometimes be mandatory. If you are feeling adventurous, however, the Eurail system and the Italian buses are capable."
            ,
                PageNumber = 3
            });
            

            callback(pageCollection, null);
            return;
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
    

        public void  UpdateUserJournal(string username, 
            IEnumerable<WineDataDomain.Journal> journalCollectionModified, 
            Action<bool,Exception> callback)
        {
            var query = from j in journalCollectionModified.ToList()
                        select j;

            MessageBox.Show(query.FirstOrDefault().Text);

        }
    }
}