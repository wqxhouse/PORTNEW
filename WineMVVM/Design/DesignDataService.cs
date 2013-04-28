using System;
using WineMVVM.Model;
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