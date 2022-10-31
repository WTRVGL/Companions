using System.ComponentModel.DataAnnotations;

namespace Companions.API.Models
{
    public class Entity
    {
        [Key]
        public string Id { get; set; }
        public DateTime DateCreated { get;}   

        public Entity()
        {
            Id = Guid.NewGuid().ToString();
            DateCreated = DateTime.Now; 
        }
    }
}
