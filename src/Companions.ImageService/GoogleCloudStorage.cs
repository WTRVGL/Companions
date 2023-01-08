using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;

namespace Companions.ImageService
{
    public class GoogleCloudStorage : ICloudStorage
    {
        private readonly GoogleCredential googleCredential;
        private readonly StorageClient storageClient;
        private readonly string bucketName;

        public GoogleCloudStorage(IConfiguration configuration)
        {
            googleCredential = GoogleCredential.FromFile(configuration.GetValue<string>("GoogleServiceKey"));
            storageClient = StorageClient.Create(googleCredential);
            bucketName = configuration.GetValue<string>("StorageBucket");
        }

        public async Task<string> UploadFileAsync(Stream stream, string fileNameForStorage)
        {
            var dataObject = await storageClient.UploadObjectAsync(bucketName, fileNameForStorage, null, stream);
            var url = $"https://storage.googleapis.com/companions_bucket01/{Uri.EscapeDataString(dataObject.Name)}";
            return url;
        }

        public async Task DeleteFileAsync(string fileNameForStorage)
        {
            await storageClient.DeleteObjectAsync(bucketName, fileNameForStorage);
        }
    }
}