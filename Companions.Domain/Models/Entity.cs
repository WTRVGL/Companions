using System.ComponentModel.DataAnnotations;

namespace Companions.Domain
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
