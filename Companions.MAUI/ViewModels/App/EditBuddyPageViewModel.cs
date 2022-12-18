using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Models.App;
using Companions.MAUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.ViewModels.App
{
    [QueryProperty("Buddy", "Buddy")]
    public partial class EditBuddyPageViewModel : BaseViewModel
    {
        private readonly IBuddyService _buddyService;
        public EditBuddyPageViewModel(IBuddyService buddyService)
        {
            _buddyService = buddyService;
        }

        [ObservableProperty]
        private Buddy _buddy;

        [ObservableProperty]
        private string _selectedGender;

        [RelayCommand]
        async void GoBack() 
        {
            var newBuddy = Buddy;

            if(SelectedGender != null)
            {
                newBuddy.Gender = SelectedGender;
            }

            _buddyService.UpdateBuddy(newBuddy);

            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
