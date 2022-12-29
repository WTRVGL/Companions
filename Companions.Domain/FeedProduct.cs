using System.ComponentModel.DataAnnotations;

namespace Companions.Domain
{
    public class FeedProduct : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public FeedBrand BrandName { get; set; }
        public string ProductURL { get; set; }
    }
}