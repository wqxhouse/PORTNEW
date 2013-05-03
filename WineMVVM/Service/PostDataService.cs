using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WineMVVM.Service
{
    public class PostDataService : IPostDataService
    {
        public void GetData(Action<IEnumerable<Database.Post>, Exception> callback)
        {
            throw new NotImplementedException();
        }
    }
}
