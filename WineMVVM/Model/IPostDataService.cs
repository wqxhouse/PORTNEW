using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WineMVVM.Model
{
    public interface IPostDataService
    {
        void GetData(Action<IEnumerable<Database.Post>, Exception> callback);
    }
}
