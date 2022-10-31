using System.ComponentModel.DataAnnotations;

namespace Companions.Domain
{
    public class FeedBrand : Entity
    {
        [Required]
        public string Name { get; set; }
        public List<FeedProduct> FeedProducts { get; set; }
    }
}