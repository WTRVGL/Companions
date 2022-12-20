namespace Companions.ImageService
{
    public interface ICloudStorage
    {
        Task<string> UploadFileAsync(Stream stream, string fileNameForStorage);
        Task DeleteFileAsync(string fileNameForStorage);
    }
}
