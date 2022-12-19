using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
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
            var url = await _cloudStorage.UploadFileAsync(stream, GenerateFileName(file.FileName));
            return url;
        }

        private static string GenerateFileName(string name)
        {
            var fileNameWithoutExtension = GetFileNameWithoutExtension(name);
            var fileNameForStorage = $"{fileNameWithoutExtension}-{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            return fileNameForStorage;
        }
    }
}
