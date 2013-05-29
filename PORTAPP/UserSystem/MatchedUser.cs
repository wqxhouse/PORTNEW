using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PORTAPP.UserSystem
{
    public class MatchedUser : WineDataDomain.User
    {

        public MatchedUser()
        {
            Similarity = 0;
            MatchedItem = new List<int>();
        }
        //extra fields
        public double Similarity { get; set; }
        public List<int> MatchedItem { get; set; }
    }
}
