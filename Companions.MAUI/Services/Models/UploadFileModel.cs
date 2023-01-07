using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services.Models
{
    public class UploadFileModel
    {
        public Stream Stream { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
    }
}
