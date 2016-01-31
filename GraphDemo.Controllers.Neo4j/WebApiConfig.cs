using GraphDemo.Controllers.Neo4j.Data;
using Neo4jClient;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace GraphDemo.Controllers.Neo4j
{
    public static class WebApiConfig
    {
        public static void Neo4jConfiguration()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == Neo4jSettings.METADATA_TYPE);
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            //Use an IoC container and register as a Singleton
            string url = Properties.Settings.Default.GraphDBUrl;
            string user = Properties.Settings.Default.GraphDBUser;
            string password = Properties.Settings.Default.GraphDBPassword;

            IGraphClient client = new GraphClient(new Uri(url), user, password);
            client.Connect();

            GraphClient = client;

            DataService = new Neo4jDataService(GraphClient);
            Cache = new Neo4jCacheQuery();

            Helper = new Neo4jHelper(DataService, Cache);
        }

        public static IGraphClient GraphClient { get; private set; }
        public static Neo4jHelper Helper { get; private set; }

        public static ICacheQuery<String> Cache { get; private set; }
        public static INeo4jDataService DataService { get; private set; }
    }
}
