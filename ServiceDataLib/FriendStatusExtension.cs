using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceDataLib
{
    public partial class FriendStatus
    {
        public WineDataDomain.FriendList ToDomainFriendList()
        {
            var fl = new WineDataDomain.FriendList();
            fl.fromUserId = this.FromUserId;
            fl.ToUserId = this.ToUserId;
            fl.Status = this.StatusId;
            return fl;
        }
    }
}
