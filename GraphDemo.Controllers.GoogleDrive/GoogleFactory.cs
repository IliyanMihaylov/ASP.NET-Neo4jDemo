using Google.Apis.Drive.v2;
using GraphDemo.Controllers.GoogleDrive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GraphDemo.Controllers.GoogleDrive
{
    public class GoogleFactory
    {
        public static async Task<GoogleDrive> ConnectToGoogleDrive(Controller controller, CancellationToken token)
        {
            DriveService service = await GoogleDriveConnection.Connect(controller, new AppFlowMetadata(), token, GoogleDriveSettings.APP_NAME);

            return new GoogleDrive(new DriveDataService(service));
        }
    }
}
