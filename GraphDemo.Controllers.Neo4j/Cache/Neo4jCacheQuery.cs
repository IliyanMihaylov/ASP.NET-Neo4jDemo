using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDemo.Controllers.Neo4j
{
    public class Neo4jCacheQuery : ICacheQuery<string>
    {
        private const int CAPACITY = 100;

        private Cache<string, string> Cache;

        public Neo4jCacheQuery(int capacity)
        {
            Cache = new Cache<string, string>(capacity);
        }

        public Neo4jCacheQuery()
            : this(CAPACITY)
        {
        }

        public string Pop()
        {
            string result = Cache.First().Key;
            Cache.ExcludeLastItem();

            return result;
        }

        public void Push(string query)
        {
            Cache.Packet(query, query);
        }
    }
}
