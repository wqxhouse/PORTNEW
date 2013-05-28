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

        public void GetUserPages(string username, System.Action<System.Collections.Generic.IEnumerable<WineDataDomain.JournalPage>, System.Exception> callback)
        {
            //string text = "Assignment 2C\r\n Main Claim: \r\nBorrowing ideas from works of others is permissible if the borrowed ideas are used as bases of creative works with new ideas with the source appropriately cited. Idea borrowers need to ask the authors of original works for permission to cite a large portion of the works; small portion of content, however, can be cited directly without permission. However, omitting citation is not permissible and is considered as plagiarism.";
            //var pageCollection = new DeferrableObservableCollection<WineDataDomain.JournalPage>();


            //int WCount = 0;
            //int HCount = 0;
            //int count = 0;
            //int total = text.Length;
            //int height = h / hInput;
            //int width = w / wInput;
            //int complement = 0;
            //int pageNumber = 0;

            //string temp = "";
            //string txt = "";

            //while (count < total)
            //{
            //    /*while (WCount < width)
            //    {
            //        if (count == total)
            //        {
            //            txt += temp;
            //            /*Console.WriteLine(txt);
            //            pageNumber++;
            //            pageCollection.Add(new WineDataDomain.JournalPage()
            //            {
            //                OverlayTopLeftColor = Color.FromArgb(102, 108, 132, 60),
            //                OverlayBottomRightColor = Color.FromArgb(102, 208, 255, 113),
            //                Header = "Cuisine",
            //                ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/003.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
            //                Text = txt,
            //                PageNumber = pageNumber
            //            });
            //            callback(pageCollection, null);
            //            return;
            //        }
            //        else if (text[count] == ' ')
            //        {
            //            txt += temp;
            //            txt += ' ';
            //            temp = "";
            //            count++;
            //            WCount++;
            //            complement = 0;
            //        }*/

            //        /*else*/ if ((int)text[count] == 13)
            //        {
            //            txt += temp;
            //            temp = "";
            //            txt += (char)(13);
            //            txt += (char)(10);
            //            count = count + 2;
            //            WCount = 0;
            //            complement = 0;
            //            HCount++;
            //            /******************** it needs to be deleted *********************************/
            //            /*Console.WriteLine(txt);
            //            txt = "";*/
            //            /******************** it needs to be deleted *********************************/

            //        }
            //        else
            //        {
            //            txt += text[count];
            //            count++;
            //        }
            //        /*else
            //        {
            //            temp += text[count];
            //            count++;
            //            WCount++;
            //            complement++;
            //        }*/
            //    }
            //    /*if (text[count] == ' ')
            //    {
            //        txt += temp;
            //        temp = "";
            //        complement = 0;
            //    }*/

            //    /*if (complement != 0)
            //    {
            //        while (complement > 0)
            //        {
            //            txt += ' ';
            //            complement--;
            //        }
            //    }*/
            //    /******************** it needs to be deleted *********************************/
            //    /* Console.WriteLine(txt);
            //     txt = "";*/
            //    /******************** it needs to be deleted *********************************/

            //    HCount++;
            //    /*txt += (char)(13);
            //    txt += (char)(10);*/
            //    if (HCount == height)
            //    {
            //        pageNumber++;
            //        pageCollection.Add(new WineDataDomain.JournalPage()
            //        {
            //            OverlayTopLeftColor = Color.FromArgb(102, 108, 132, 60),
            //            OverlayBottomRightColor = Color.FromArgb(102, 208, 255, 113),
            //            Header = "Cuisine",
            //            ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/003.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
            //            Text = txt,
            //            PageNumber = pageNumber
            //        });
            //        txt = "";
            //        HCount = 0;
            //    }
            //    if (temp.Length != 0)
            //    {
            //        WCount = temp.Length;
            //    }
            //    else
            //    {
            //        WCount = 0;
            //    }

            //}
            //txt += temp;
            //Console.WriteLine(txt);

            //callback(pageCollection, null);
            //return;

            
            var pageCollection = new DeferrableObservableCollection<WineDataDomain.JournalPage>();
             
            pageCollection.Add(new WineDataDomain.JournalPage()
            {
                OverlayTopLeftColor = Color.FromArgb(102, 85, 50, 50),
                OverlayBottomRightColor = Color.FromArgb(102, 255, 50, 50),
                Header = "Travel in Italy",
                ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/001.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
                Text = "\tSonata, op 110 mainly focuses on slow, moderate and allegretto speed, giving a presentation of a range of styles. The Moderato cantabile molto espressivo stays on the sonata form in a predictable manner: exposition, development, recapitulation. Base line follows the main melody in classical wa"	

           ,
                PageNumber = 0 
            });


            pageCollection.Add(new WineDataDomain.JournalPage()
            {
                OverlayTopLeftColor = Color.FromArgb(102, 142, 64, 64),
                OverlayBottomRightColor = Color.FromArgb(102, 113, 255, 255),
                Header = "Sightseeing",
                ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/002.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
                Text = " with homophonic texture. A distinct feature of Allegro molto movement is the use of syncopation, which makes the music unpredictable, thus adding richness. In the movement Adagio, ma non Troppo, despite having a slow beats, the color changes from one with passion to a relatively dark one with me"	

            ,
                PageNumber = 1
            });


            pageCollection.Add(new WineDataDomain.JournalPage()
            {
                OverlayTopLeftColor = Color.FromArgb(102, 108, 132, 60),
                OverlayBottomRightColor = Color.FromArgb(102, 208, 255, 113),
                Header = "Cuisine",
                ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/003.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
                Text = "ancholy. \r\n\tThe pieces on the concert are mainly from classical period. It is hard to find the polyphonic and monophonic texture before music in baroque period. Instead, the pieces are filled with homophonic texture, featuring the music textures in late baroque periods. "	
            ,
                PageNumber = 2
            });


            pageCollection.Add(new WineDataDomain.JournalPage()
            {
                OverlayTopLeftColor = Color.FromArgb(102, 142, 64, 64),
                OverlayBottomRightColor = Color.FromArgb(102, 113, 255, 255),
                Header = "Getting Around",
                ImageSource = new BitmapImage(new Uri("/PORTNEW;component/PORTAPP/Design/images/004.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.None },
                Text = "he new form of presentation of music may due to the invention of piano, which is capable of delivering emotions to the music, making homophonic notes better running in different dynamic layers, delivering the perception of scene with weighted notes. "

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