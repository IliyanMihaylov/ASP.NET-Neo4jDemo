using System.Collections.Generic;
using System.Linq;
using System;

namespace GraphDemo.Controllers.Neo4j
{
    public class Relation<TSource, TTarget>
    {
        public TSource Source { get; set; }
        public TTarget Target { get; set; }
    }
}
