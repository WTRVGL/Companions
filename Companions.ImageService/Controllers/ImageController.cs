using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.IO;
using System.Net.Mime;
using static System.IO.Path;

namespace Companions.ImageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ICloudStorage _cloudStorage;

        public ImageController(ICloudStorage cloudStorage)
        {
            _cloudStorage = cloudStorage;
        }

        [HttpPost(nameof(UploadFile))]
        [SwaggerOperation("Upload submitted image to Google Cloud Storage Bucket")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(string), Description = "Returns Bucket URL of uploaded image")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
        public async Task<string> UploadFile(IFormFile file)
        {
            var stream = file.OpenReadStream();
            var fileExtension = GetExtension(file.FileName);
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
