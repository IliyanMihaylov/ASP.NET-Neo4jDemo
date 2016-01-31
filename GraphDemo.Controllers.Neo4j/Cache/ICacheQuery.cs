using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDemo.Controllers.Neo4j
{
    public interface ICacheQuery<T>
    {
        void Push(T query);
        T Pop();
    }
}
