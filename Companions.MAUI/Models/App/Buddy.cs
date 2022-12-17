using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Models.App
{
    public class Buddy
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
        public string ImageURL { get; set; }
        public string Gender { get; set; }
        public int Weight { get; set; }
        public List<Activity> Activities { get; set; }
        public List<FeedingSchedule> FeedingSchedules { get; set; }


    }
}
