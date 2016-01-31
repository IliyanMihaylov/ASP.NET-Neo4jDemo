using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GraphDemo.Controllers.GoogleDrive
{
    public class GoogleDriveConnection
    {
        private static DriveService Service = null;

        public static async Task<DriveService> Connect(Controller controler, FlowMetadata flowMetadata, CancellationToken cancellationToken, string appName)
        {
            if (Service != null)
                return Service;

            var result = await new AuthorizationCodeMvcApp(controler, flowMetadata).AuthorizeAsync(cancellationToken);

            if (result.Credential == null)
                return null;

            Service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = result.Credential,
                ApplicationName = appName
            });

            return Service;
        }
    }
}
