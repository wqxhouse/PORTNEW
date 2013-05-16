﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WineDataDomain
{
    //needs refactor, separating Journal and JouranlPage
    public interface IJournalPageRepository
    {
        void GetUserPages(string username, Action<IEnumerable<JournalPage>, Exception> callback);
        void GetUserJournalCollection(string username, Action<IEnumerable<Journal>, Exception> callback);
       
    }
}