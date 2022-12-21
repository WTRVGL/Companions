using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Mime;
using static System.IO.Path;

namespace Companions.ImageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ICloudStorage _cloudStorage;

        public ImagesController(ICloudStorage cloudStorage)
        {
            _cloudStorage = cloudStorage;

        }

        [HttpPost]
        public async Task<string> UploadFile(IFormFile file)
        {
            var stream = file.OpenReadStream();
            var fileExtension = Path.GetExtension(file.FileName);
            var url = await _cloudStorage.UploadFileAsync(stream, GenerateFileName(file.FileName, fileExtension));
            return url;
        }

        private static string GenerateFileName(string name, string fileExtension)
        {
            var fileNameWithoutExtension = GetFileNameWithoutExtension(name);
            var fileNameForStorage = $"{fileNameWithoutExtension}-{DateTime.Now.ToString("yyyyMMddHHmmss")}{fileExtension}";
            return fileNameForStorage;
        }
    }
}
