using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Models.App;
using Companions.MAUI.Services;
using Companions.MAUI.Views.App;
using Companions.MAUI.Views.App.BuddyDetail;
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
        private readonly IBuddyService _buddyService;

        [ObservableProperty]
        private bool _isRefreshing;

   
        
        [ObservableProperty]
        private ObservableCollection<Buddy> _buddies;

        [ObservableProperty]
        private ObservableCollection<UpcomingActivities> _upcomingActivities;

        [RelayCommand]
        async void Refresh()
        {
            
            await Shell.Current.GoToAsync(nameof(HomePage),false);
            var previousPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
            Application.Current.MainPage.Navigation.RemovePage(previousPage);
            IsRefreshing = false;
        }


        [RelayCommand]
        async void OpenBuddyDetail(Buddy buddy)
        {
            await Shell.Current.GoToAsync(nameof(BuddyDetailPage),
                new Dictionary<string, object>
                {
                    {"Buddy",buddy }
                });

        }

        public HomePageViewModel(IBuddyService buddyservice)
        {
            _buddyService = buddyservice;
            _buddies = _buddyService.GetBuddies();

            _upcomingActivities = new ObservableCollection<UpcomingActivities>()
            {
                new UpcomingActivities {ActivityName = "CPV Vaccinatie", BuddyName = "Ori", ActivityDate = new DateTime(2022,12,24)},
                new UpcomingActivities {ActivityName = "CPV Vaccinatie", BuddyName = "Bassie", ActivityDate = new DateTime(2022,12,24)},
            };
        }

    }
}
