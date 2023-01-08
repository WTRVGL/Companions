using System.ComponentModel.DataAnnotations;

namespace Companions.API.DTOs
{
    public class FeedProductDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string ProductURL { get; set; }
    }
}