using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDemo.Controllers.Neo4j
{
    public class Neo4jSettings
    {
        public const string USER_LABEL = "Users";
        public const string LINK_LABEL = "KNOWS";

        public const string GRAPH_VIEW = "Graph";

        // Graph client 
        public const string METADATA_TYPE = "application/xml";
    }
}
