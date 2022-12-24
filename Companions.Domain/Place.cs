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
        public Location Location { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
