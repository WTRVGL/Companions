namespace Companions.ImageService.Models
{
    public class Image
    {
        public virtual IFormFile ImageFie { get; set; } 
        public string ImageName { get; set; }
    }
}
