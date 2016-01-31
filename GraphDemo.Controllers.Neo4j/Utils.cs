using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDemo.Controllers.Neo4j
{
    public class Utils
    {
        public static List<object> CalculateLinks<T>(IEnumerable<T> nodes, IEnumerable<Relation<T,T>> relations, IComparer<T> comaprer)
        {
            Dictionary<T, int> cache = new Dictionary<T, int>();
            List<object> result = new List<object>();

            List<T> sortNodes = nodes.ToList();
            sortNodes.Sort(comaprer);

            int indexSource = 0;
            int indexTarget = 0;

            foreach (Relation<T,T> ralation in relations)
            {
                indexSource = GetIndex(cache, sortNodes, ralation.Source, comaprer);
                indexTarget = GetIndex(cache, sortNodes, ralation.Target, comaprer);
               
                result.Add(new { source = indexSource, target = indexTarget });
            }

            return result;
        }

        public static int GetIndex<T>(Dictionary<T, int> cache, List<T> items, T item, IComparer<T> comparer)
        {
            int index = -1;

            if (cache.ContainsKey(item))
                index = cache[item];
            else
            {
                index = items.BinarySearch(item, comparer); // Will always exist.
                cache[item] = index;
            }

            return index;
        }
    }
}
