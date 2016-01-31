using System.Collections.Generic;
using System.Linq;
using System;

namespace GraphDemo.Controllers.Neo4j
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string eyes { get; set; }
        public string email { get; set; }
    }

    public class UserComparer : IComparer<User>
    {
        public static UserComparer Instance = new UserComparer();

        public int Compare(User x, User y)
        {
            return x.id.CompareTo(y.id);
        }
    }
}
