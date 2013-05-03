using System;
using WineMVVM.Service;
using System.Collections.Generic;

namespace WineMVVM.Design
{
    public class DesignDataService : IUserDataService
    {
        public void GetData(Action<IEnumerable<Database.User>, Exception> callback)
        {
            
        }
    }
}