using Neo4jClient;
using Neo4jClient.Cypher;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using System;

namespace GraphDemo.Controllers.Neo4j
{
    [RoutePrefix("graph")]
    public class GraphController : ApiController
    {
        [HttpGet]
        [Route("{limit:int?}", Name = "Index")]
        public IHttpActionResult Index(int limit = 100)
        {
            WebApiConfig.Helper.ExecuteLastUserQuery(); // Execute last query in cache.

            IEnumerable<User> nodes = WebApiConfig.Helper.LoadNodes<User>(Neo4jSettings.USER_LABEL);
            List<Relation<User,User>> rels1 = WebApiConfig.Helper.LoadRelations<User, User>(Neo4jSettings.LINK_LABEL);

            List<object> rels = Utils.CalculateLinks(nodes, rels1, UserComparer.Instance);

            return Ok(new { nodes = nodes, links = rels });
        }
    }
}


