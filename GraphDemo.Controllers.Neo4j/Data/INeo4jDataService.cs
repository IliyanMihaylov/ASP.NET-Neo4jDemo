using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDemo.Controllers.Neo4j.Data
{
    public interface INeo4jDataService
    {
        void ExecuteQueryWithoutResults(string query);

        void LoadCSVFileWithHeader(string fileUrl, string match, string create, bool usePeriodicCommit = true);
        void LoadCSVFileWithoutHeader(string fileUrl, string match, string create, bool usePeriodicCommit = true);

        void CreateIndex(string label, string property);
        void DropIndex(string label, string property);

        IEnumerable<T> GetUserNodes<T>(string label);
        IEnumerable<Relation<TSource, TTarget>> GetRelationshipBetweenUsers<TSource, TTarget>(string label);
    }
}
