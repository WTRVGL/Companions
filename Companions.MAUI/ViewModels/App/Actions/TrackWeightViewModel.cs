using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Models.App;
using Companions.MAUI.Services;
using Companions.MAUI.Services.Models;
using Syncfusion.Maui.DataSource.Extensions;
using Syncfusion.Maui.ListView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.ViewModels.App.Actions
{
    public partial class TrackWeightViewModel : BaseViewModel
    {
        private readonly IBuddyService _buddyService;
        private readonly IActivityService _activityService;

        public TrackWeightViewModel(IBuddyService buddyService, IActivityService activityService)
        {
            _buddyService = buddyService;
            Task.Run(async () => await FetchDataAsync()).Wait();
            _activityService = activityService;
        }


        [ObservableProperty]
        private Buddy _selectedBuddy;

        [ObservableProperty]
        private double selectedWeight;

        [ObservableProperty]
        private ObservableCollection<Buddy> _buddies;


        [RelayCommand]
        async void GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        async Task FetchDataAsync()
        {
            Buddies = await _buddyService.GetBuddies();
        }

        [RelayCommand]
        async void BuddySelected()
        {

        }

        [RelayCommand]
        async void AddWeight()
        {
            var selectedBuddy = (Buddy)SelectedBuddy;

            var createWeight = new BuddyWeight
            {
                BuddyId = selectedBuddy.Id,
                DateWeighed = DateTime.Now,
                Weight = Math.Round(SelectedWeight, 2)
            };

            var buddy = selectedBuddy;
            buddy.BuddyWeights.Add(createWeight);

            var updatedBuddy = await _buddyService.UpdateBuddy(buddy);

            List<ActivityType> types = await _activityService.GetActivityTypes();
            var walkActivity = types.FirstOrDefault(a => a.Name == "Weight");

            var createActivity = new Activity
            { 
                ActivityType = walkActivity,
                BuddyId = selectedBuddy.Id,
                EndDate = DateTime.Now,
                StartDate  = DateTime.Now,
            };

            var createdActivity = await _activityService.CreateActivity(createActivity);


            //    //Display notification and close
            await Application.Current.MainPage.DisplayAlert("Succes", "Sucesfully recorded weight", "Ok");
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}