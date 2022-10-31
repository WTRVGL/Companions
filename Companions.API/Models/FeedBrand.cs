namespace Companions.API.Models
{
    public class FeedBrand : Entity
    {
        public string Name { get; set; }
        public List<FeedProduct> FeedProducts { get; set; }
    }
}