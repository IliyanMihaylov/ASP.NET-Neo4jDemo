using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDemo.Models
{
    public class DonwloadFile
    {
        public string Id { get; set; }

        [DataType(DataType.MultilineText)]
        public string Query { get; set; }
    }

    public class FileViewModel
    {
        [Key]
        public int Id { get; set; }
        public FileModel File { get; set; }
        public bool Selected { get; set; }
    }

    public class FileModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string DownloadUrl { get; set; }

        public string Type { get; set; }
        public string Size { get; set; }

        public bool Selected { get; set; }
    }
}
