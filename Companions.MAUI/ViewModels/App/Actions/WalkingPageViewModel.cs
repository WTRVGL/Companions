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
    public partial class WalkingPageViewModel : BaseViewModel
    {
        private readonly IBuddyService _buddyService;
        private readonly IActivityService _activityService;

        public WalkingPageViewModel(IBuddyService buddyService, IActivityService activityService)
        {
            _buddyService = buddyService;
            SelectedBuddies = new ObservableCollection<object>();
            _activityService = activityService;

            Task.Run(async () => await FetchDataAsync()).Wait();
        }


        [ObservableProperty]
        private ObservableCollection<object> _selectedBuddies;

        [ObservableProperty]
        private ObservableCollection<Buddy> _buddies;


        [RelayCommand]
        async void GoBack()
        {
            ////Update appointment in db
            //var updatedAppointment = _appointmentService.UpdateAppointment(Appointment);
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
            FeedingSchedules = new ObservableCollection<ActionFeedingSchedule>();

            foreach (Buddy buddy in SelectedBuddies)
            {
                var schedule = new ActionFeedingSchedule
                {
                    BuddyName = buddy.Name,
                    FeedingSchedules = buddy.FeedingSchedules
                };

                FeedingSchedules.Add(schedule);
            }
        }

        [RelayCommand]
        async void AddFeeding()
        {

            List<FeedingSchedule> checkedFeedings = new List<FeedingSchedule>();

            if (FeedingSchedules.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Nothing was selected", "Ok");
                return;
            }

            //Adds any FeedingSchedule to checkedFeedings if it is checked
            for (int i = 0; i < FeedingSchedules.Count; i++)
            {
                for (int j = 0; j < FeedingSchedules[i].FeedingSchedules.Count; j++)
                {
                    if (FeedingSchedules[i].FeedingSchedules[j].IsChecked)
                    {
                        checkedFeedings.Add(FeedingSchedules[i].FeedingSchedules[j]);
                    }
                }
            }

            //Get Id of Feeding Activity
            var activityTypes = await _activityService.GetActivityTypes();
            var feedingActivityType = activityTypes.FirstOrDefault(a => a.Name == "Feeding");
            if (feedingActivityType == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Feeding id not found", "Ok");
            }

            foreach (var feedingActivity in checkedFeedings)
            {
                var createActivity = new Activity
                {
                    ActivityType = feedingActivityType,
                    EndDate = DateTime.Now,
                    StartDate = DateTime.Now,
                    BuddyId = feedingActivity.BuddyId,
                };

                var createdActivity = await _activityService.CreateActivity(createActivity);
            }

            //Display notification and close
            await Application.Current.MainPage.DisplayAlert("Succes", "Sucesfully added Feeding Activity", "Ok");
            await Application.Current.MainPage.Navigation.PopAsync();

        }


        [RelayCommand]
        async void FeedingChecked(CheckedChangedEventArgs e)
        {
        }
    }
}
