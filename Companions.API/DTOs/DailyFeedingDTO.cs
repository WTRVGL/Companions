using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Companions.API.DTOs.Buddy;

namespace Companions.API.DTOs
{
    public class DailyFeedingDTO
    {
        public string Id { get; set; }
        public BuddyDTO BuddyDTO { get; set; }
        public FeedingScheduleDTO FeedingSchedule { get; set; }
        public DateTime Date { get; set; }
    }
}
