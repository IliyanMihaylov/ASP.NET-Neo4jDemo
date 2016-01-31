using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GraphDemo.Controllers.Neo4j.Data
{
    public class Neo4jHelper
    {
        public INeo4jDataService DataService { get; private set; }
        public ICacheQuery<string> Cache { get; private set; }

        public Neo4jHelper(INeo4jDataService dataservice, ICacheQuery<string> cache)
        {
            DataService = dataservice;
            Cache = cache;
        }

        public void ExecuteLastUserQuery()
        {
            string query = Cache.Pop();
            Regex linkParserUrl = new Regex(@"\b(?:https?://|www\.|file:\///)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            string createQuery;
            string matchQuery;
            var files = query.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in files)
            {
                if (item.Contains("User"))
                {
                    createQuery = "(:Users {id: line.id, name: line.name, eyes: line.eyes, email: line.email})";
                    DataService.LoadCSVFileWithHeader(linkParserUrl.Match(item).Value, null, createQuery);
                    DataService.CreateIndex("Users", "id");
                }
                else
                {
                    createQuery = "(u1) -[:KNOWS]->(u2)";
                    matchQuery = "(u1:Users {id: line.fromId}), (u2:Users {id: line.toId})";

                    DataService.LoadCSVFileWithHeader(linkParserUrl.Match(item).Value, matchQuery, createQuery);
                }
            }
        }

        public IEnumerable<T> LoadNodes<T>(string label)
        {
            return DataService.GetUserNodes<T>(label);
        }

        public List<Relation<TSource, TTarget>> LoadRelations<TSource, TTarget>(string label)
        {
            return DataService.GetRelationshipsBetweenUsers<TSource, TTarget>(label).ToList();
        }
    }
}
