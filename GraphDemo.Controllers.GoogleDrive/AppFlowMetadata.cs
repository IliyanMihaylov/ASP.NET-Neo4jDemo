using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Drive.v2;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GraphDemo.Controllers.GoogleDrive
{
    public class AppFlowMetadata : FlowMetadata
    {
        private static readonly IAuthorizationCodeFlow flow =
            new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = GoogleDriveSettings.CLIENT_ID,
                    ClientSecret = GoogleDriveSettings.CLIENT_SECRET
                },
                Scopes = new[] { DriveService.Scope.Drive },
                DataStore = new FileDataStore(GoogleDriveSettings.FOLDER)
            });
        
        public override string GetUserId(System.Web.Mvc.Controller controller)
        {
            return GoogleDriveSettings.DEVELOPER_EMAIL;
        }

        public override IAuthorizationCodeFlow Flow
        {
            get { return flow; }
        }
    }
}
