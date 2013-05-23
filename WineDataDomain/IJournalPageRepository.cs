using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WineDataDomain
{
    //needs refactor, separating Journal and JouranlPage
    public interface IJournalPageRepository
    {
        void GetUserPages(int tWidth, int tHeight, int wWidth, int wHeight, string username, Action<IEnumerable<JournalPage>, Exception> callback);
        void GetUserJournalCollection(string username, Action<IEnumerable<Journal>, Exception> callback);
        void UpdateUserJournal(string username, IEnumerable<Journal> journalCollectionModified, Action<bool, Exception> callback);
       
    }
}
