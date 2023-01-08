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
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
