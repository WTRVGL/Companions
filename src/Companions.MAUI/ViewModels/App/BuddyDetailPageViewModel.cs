using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.Domain;
using Companions.MAUI.Models.App;
using Companions.MAUI.Services.Interface;
using Companions.MAUI.Views.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buddy = Companions.MAUI.Models.App.Buddy;

namespace Companions.MAUI.ViewModels.App
{
    [QueryProperty("Buddy","Buddy")]
    public partial class BuddyDetailPageViewModel : BaseViewModel
    {

        private readonly IBuddyService _buddyService;

        public BuddyDetailPageViewModel(IBuddyService buddyService)
        {
            _buddyService = buddyService;
        }

        [ObservableProperty]
        private Buddy _buddy;

        [RelayCommand]
        async void GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        async void BuddySettings()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Change Buddy", "Cancel", null, "Edit Buddy", "Delete Buddy");
            if (action == "Delete Buddy")
            {
                var secondAction = await Application.Current.MainPage.DisplayActionSheet("Are you sure?", "Cancel", null, "Delete Buddy");
                if (secondAction == "Delete Buddy")
                {
                    var deleted = await _buddyService.DeleteBuddy(Buddy.Id);
                    if (!deleted) await Application.Current.MainPage.DisplayAlert("Error", "Appointment couldn't be deleted", "Ok");
                    GoBack();
                }
            }

            if (action == "Edit Buddy")
            {
                await Shell.Current.GoToAsync(nameof(EditBuddyPage),
                new Dictionary<string, object>
                {
                    {"Buddy", Buddy}
                });
            }
        }

        //Sort Activities list. (why here tho?)
        partial void OnBuddyChanged(Buddy buddy)
        {
            var orderedActivities = Buddy.Activities.OrderByDescending(a => a.StartDate).ToList();
            Buddy.Activities = orderedActivities;
        }

    }

}
