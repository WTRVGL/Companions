﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Models.App
{
    public class DailyFeeding
    {
        public FeedingSchedule FeedingSchedule { get; set; }
        public string BuddyId { get; set; }
        public DateTime Time { get; set; }
    }
}
