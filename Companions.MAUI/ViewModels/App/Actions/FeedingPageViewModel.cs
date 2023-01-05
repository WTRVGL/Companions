using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Models.App;
using Companions.MAUI.Services;
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
    public partial class FeedingPageViewModel : BaseViewModel
    {
        private readonly IBuddyService _buddyService;

        public FeedingPageViewModel(IBuddyService buddyService)
        {
            _buddyService = buddyService;
            SelectedBuddies = new ObservableCollection<object>();
            _feedingSchedules = new ObservableCollection<ActionFeedingSchedule>();

            Task.Run(async () => await FetchDataAsync()).Wait();
        }


        [ObservableProperty]
        private ObservableCollection<object> _selectedBuddies;

        [ObservableProperty]
        private ObservableCollection<Buddy> _buddies;

        [ObservableProperty]
        private ObservableCollection<ActionFeedingSchedule> _feedingSchedules;

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


        }


        [RelayCommand]
        async void FeedingChecked(CheckedChangedEventArgs e)
        {
        }
    }
}
