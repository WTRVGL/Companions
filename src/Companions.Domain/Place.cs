using Companions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.Domain
{
    public class Place : Entity
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
