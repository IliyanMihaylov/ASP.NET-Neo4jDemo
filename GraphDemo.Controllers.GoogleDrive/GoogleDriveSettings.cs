using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDemo.Controllers.GoogleDrive
{
    public class GoogleDriveSettings
    {
        public const string CLIENT_ID = "48487136346-iaeq6te6cvm8m07e4m6f8dtf1fdm71q5.apps.googleusercontent.com";
        public const string CLIENT_SECRET = "rLwSvOEOfICGj0ldlcClYxCN";
        public const string FOLDER = "Drive.Api.Auth.Store";

        public const string DEVELOPER_EMAIL = "drakola31415926535@gmail.com";
        public const string APP_NAME = "Graph Demo";

        public static readonly HashSet<string> AllowExtensions = new HashSet<String>()
        {
            "cypher",
            "csv",
            "xml"
        };
    }
}
