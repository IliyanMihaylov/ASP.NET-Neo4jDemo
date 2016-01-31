using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Drive.v2.Data;
using GraphDemo.Controllers.GoogleDrive;
using Google.Apis.Drive.v2;
using System.IO;

namespace GraphDemo.Controllers.GoogleDrive
{
   public class DriveDataService : IDriveDataService
    {
        private DriveService ConnectionService;

        public DriveDataService(DriveService connectionService)
        {
            if (connectionService == null)
                throw new ArgumentNullException("connectionService == null");

            ConnectionService = connectionService;
        }

        public Task<FileList> FilesAsync
        {
            get
            {
                return ConnectionService.Files.List().ExecuteAsync();
            }
        }
        
        public async Task<string> ReadFileAsync(string url)
        {
            if (ConnectionService == null)
                return string.Empty;

            Stream stream = await ConnectionService.HttpClient.GetStreamAsync(url);
            StreamReader reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }

        public string ReadFile(string url)
        {
            return ReadFileAsync(url).Result;
        }
    }
}
