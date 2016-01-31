using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using GraphDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GraphDemo.Controllers.GoogleDrive
{
    public class GoogleDriveController : Controller
    {
        // GET: GoogleDrive
        [Authorize]
        public async Task<ActionResult> Drive(CancellationToken cancellationToken)
        {
            GoogleDrive drive;

            try
            {
                drive = await GoogleFactory.ConnectToGoogleDrive(this, cancellationToken);
            }
            catch(Exception exc)
            {
                return View("Error");
            }

            IEnumerable<FileModel> files = drive.FilterFiles(GoogleDriveSettings.AllowExtensions);

            return View(files);
        }
        
        public async Task<ActionResult> Donwload(string url)
        {
            try
            {
                GoogleDrive drive = await GoogleFactory.ConnectToGoogleDrive(this, new CancellationToken());
                DonwloadFile file = await drive.DonwloadAsync(url);

                return View(file);
            }
            catch (Exception exc)
            {
                return View("Error");
            }
        }
    }
}