using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Models.App;
using Companions.MAUI.Views.App;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.ViewModels.App
{
    public partial class HomePageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<Buddy> _buddies;

        [ObservableProperty]
        private ObservableCollection<UpcomingActivitesActivityModel> _upcomingActivities;


        [RelayCommand]
        async void OpenBuddyDetail(Buddy buddy)
        {
            await Shell.Current.GoToAsync(nameof(BuddyDetailPage),
                new Dictionary<string, object>
                {
                    {"Buddy",buddy }
                });
        }

        public HomePageViewModel()
        {
            _buddies = new ObservableCollection<Buddy>()
            {
                new Buddy { Name = "Bassie", Age = 6, Race = "Mixed", Gender= "M", Weight = 6, ImageURL = "https://i.imgur.com/GJe4t90.jpg"},
                new Buddy { Name = "Ori", Age = 4, Race = "Mixed", Weight = 5, Gender = "M", ImageURL="https://i.imgur.com/UUzY06O.png"},
                new Buddy { Name = "Robot", Age = 4, Race = "Tabby",Gender = "M", Weight = 3,ImageURL="https://i.imgur.com/Z0J26m6.png"},

            };

            _upcomingActivities = new ObservableCollection<UpcomingActivitesActivityModel>()
            {
                new UpcomingActivitesActivityModel {ActivityName = "CPV Vaccinatie", BuddyName = "Ori"},
                new UpcomingActivitesActivityModel {ActivityName = "CPV Vaccinatie", BuddyName = "Bassie"},
            };
        }
    }
}
