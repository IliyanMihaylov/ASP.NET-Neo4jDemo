using Neo4jClient;
using Neo4jClient.Cypher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDemo.Controllers.Neo4j.Data
{
    public class Neo4jDataService : INeo4jDataService
    {
        public IGraphClient Client { get; private set; }

        public Neo4jDataService(IGraphClient client)
        {
            Client = client;
        }

        public void ExecuteQueryWithoutResults(string query)
        {
            CypherQuery cypherQuery = new CypherQuery(query, null, CypherResultMode.Set);
            ((IRawGraphClient)Client).ExecuteCypher(cypherQuery);
        }

        public IEnumerable<T> GetUserNodes<T>(string label)
        {
            string matchQuery = String.Format("(n:{0})", label);

            return Client.Cypher.Match(matchQuery).Return((n) => n.As<T>()).Results;
        }

        public IEnumerable<Relation<TSource, TTarget>> GetRelationshipBetweenUsers<TSource, TTarget>(string label)
        {
            string matchQuery = String.Format("((u1:Users)-[r:{0}]->(u2:Users))", label);

            IEnumerable<Relation<TSource, TTarget>> result = Client.Cypher.Match(matchQuery).Return((u1, u2) => new Relation<TSource, TTarget>
            {
                Source = u1.As<TSource>(),
                Target = u2.As<TTarget>()
            }).Results;
                        
            return result;
        }

        /// <summary>
        /// Your file must be start with headers.
        /// USING PERIODIC COMMIT 500 LOAD CSV FROM "https://gist.githubusercontent.com/jexp/d8f251a948f5df83473a/raw/friendships.csv" 
        /// AS row MATCH (p1:Person {userId: toInt(row[0])}), (p2:Person {userId: toInt(row[1])}) CREATE (p1)-[:KNOWS]->(p2)
        /// </summary>
        /// <param name="fileUrl">URL path to csv file.</param>
        /// <param name="match">Match query.</param>
        /// <param name="relationship">Relations like - CREATE (p1)-[:KNOWS]->(p2).</param>
        /// <param name="usePeriodicCommit">You can use periodic commit.</param>
        public void LoadCSVFileWithHeader(string fileUrl, string match, string create, bool usePeriodicCommit = true)
        {
            LoadCSV(fileUrl, match, create, usePeriodicCommit, true);
        }

        public void LoadCSVFileWithoutHeader(string fileUrl, string match, string create, bool usePeriodicCommit = true)
        {
            LoadCSV(fileUrl, match, create, usePeriodicCommit, false);
        }

        public void CreateIndex(string label, string property)
        {
            Client.Cypher.Create(String.Format("INDEX ON :{0}({1})", label, property)).ExecuteWithoutResults();
        }

        public void DropIndex(string label, string property)
        {
            Client.Cypher.Drop(String.Format("INDEX ON :{0}({1})", label, property)).ExecuteWithoutResults();
        }

        private void LoadCSV(string fileUrl, string match, string create, bool usePeriodicCommit, bool withHeders)
        {
            StringBuilder builder = new StringBuilder();

            if (usePeriodicCommit)
            {
                builder.Append("USING PERIODIC COMMIT ");
            }

            builder.Append("LOAD CSV");

            if (withHeders)
            {
                builder.Append(" WITH HEADERS ");
            }

            builder.Append(String.Format(" FROM \"{0}\" ", fileUrl));
            builder.Append(" AS line ");

            if (match != null && match != string.Empty)
            {
                builder.Append(String.Format(" MATCH {0}", match));
            }

            builder.Append(String.Format(" CREATE {0}", create));


            ((IRawGraphClient)Client).ExecuteCypher(new CypherQuery(builder.ToString(), null, CypherResultMode.Set));
        }
    }
}
