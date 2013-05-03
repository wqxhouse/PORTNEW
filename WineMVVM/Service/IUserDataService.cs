using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WineMVVM.Service
{
    public interface IUserDataService
    {
        void GetData(Action<IEnumerable<Database.User>, Exception> callback);
    }
}
