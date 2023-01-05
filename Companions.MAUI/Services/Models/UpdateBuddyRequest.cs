using Companions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services.Models
{
    internal class UpdateBuddyRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public List<BuddyWeight> BuddyWeights { get; set; }
    }
}
