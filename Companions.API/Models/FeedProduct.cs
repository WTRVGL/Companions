namespace Companions.API.Models
{
    public class FeedProduct : Entity
    {
        public string Name { get; set; }
        public string ProductURL { get; set; }
        public FeedBrand FeedBrand { get; set; }
    }
}