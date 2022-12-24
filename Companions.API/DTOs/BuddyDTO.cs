using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.API.DTOs
{
    public class BuddyDTO 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string ImageURL { get; set; }
        public int Weight { get; set; }
        public List<ActivityDTO> Activities { get; set; }
        public List<FeedingScheduleDTO> FeedingSchedules { get; set; }


    }
}
