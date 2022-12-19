using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        private async Task UploadFile(Stream stream)
        {
            var url = await _cloudStorage.UploadFileAsync(stream, "yoo");
        }

        private static string FormFileName(string name)
        {
            var fileNameForStorage = $"{name}-{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            return fileNameForStorage;
        }
    }
}
