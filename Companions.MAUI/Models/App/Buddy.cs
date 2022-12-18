using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Models.App
{
    public class Buddy : ObservableObject
    {

        private string _name;
        private string _race;
        private string _gender;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string Race
        {
            get => _race;
            set => SetProperty(ref _race, value);
        }
        public string Gender
        {
            get => _gender;
            set => SetProperty(ref _gender, value);
        }

        public string Id { get; set; }
        public int Age { get; set; }
        public string ImageURL { get; set; }
        public int Weight { get; set; }
        public List<Activity> Activities { get; set; }
        public List<FeedingSchedule> FeedingSchedules { get; set; }


    }
}
