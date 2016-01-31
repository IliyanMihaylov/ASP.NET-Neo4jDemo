using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GraphDemo.Controllers.Neo4j
{
    public class Neo4jController : Controller
    {
        public ActionResult Index(string query)
        {
            WebApiConfig.Cache.Push(query);

            return View(Neo4jSettings.GRAPH_VIEW);
        }
    }
}
