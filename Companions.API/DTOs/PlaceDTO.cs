using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.API.DTOs
{
    public class PlaceDTO
    {
        public string Id { get; set; }
        public LocationDTO Location { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
