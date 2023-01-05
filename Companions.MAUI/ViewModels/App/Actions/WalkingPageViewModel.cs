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
        private int _selectedDuration;

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

        }

        [RelayCommand]
        async void AddWalking()
        {
            var endTime = DateTime.Now.AddMinutes(SelectedDuration).AddSeconds(5);

            //Get Id of Walk Activity
            var activityTypes = await _activityService.GetActivityTypes();
            var walkActivityType = activityTypes.FirstOrDefault(a => a.Name == "Walk");

            if (walkActivityType == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Walk id not found", "Ok");
            }

            foreach (Buddy buddy in SelectedBuddies)
            {
                var createActivity = new Activity
                {
                    ActivityType = walkActivityType,
                    EndDate = endTime,
                    StartDate = DateTime.Now,
                    BuddyId = buddy.Id,
                };

                var createdActivity = await _activityService.CreateActivity(createActivity);
            }

            //Display notification and close
            await Application.Current.MainPage.DisplayAlert("Succes", "Sucesfully added Feeding Activity", "Ok");
            await Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}
