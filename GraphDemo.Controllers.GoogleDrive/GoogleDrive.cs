using Google.Apis.Drive.v2.Data;
using GraphDemo.Controllers.GoogleDrive;
using GraphDemo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDemo.Controllers.GoogleDrive
{
    public class GoogleDrive
    {
        public IDriveDataService DataService { get; private set; }

        public GoogleDrive(IDriveDataService dataService)
        {
            DataService = dataService;
        }

        public IEnumerable<FileModel> FilterFiles(ICollection<string> allowExtensions)
        {
            FileList list = DataService.FilesAsync.Result;

            IEnumerable<FileModel> files = list.Items
               .Where(x => x.FileExtension != null && allowExtensions.Contains(x.FileExtension.ToLower()))
               .Select(x =>
                    new FileModel()
                    {
                        Id = x.Id,
                        Title = x.Title,
                        CreatedDate = x.CreatedDate,
                        DownloadUrl = x.DownloadUrl,
                        Type = x.FileExtension,
                        Size = Utils.ResolveSize(x.FileSize ?? 0)
                    });

            return files;
        }

        public DonwloadFile Donwload(string url)
        {
            return DonwloadAsync(url).Result;
        }

        public async Task<DonwloadFile> DonwloadAsync(string url)
        {
            string result = await DataService.ReadFileAsync(url);

            DonwloadFile file = new DonwloadFile()
            {
                Query = result
            };

            return file;
        }
    }
}
