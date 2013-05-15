using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WineDataDomain
{
    public interface IJournalPageRepository
    {
        void GetUserPages(string username, Action<IEnumerable<JournalPage>, Exception> callback);
    }
}
