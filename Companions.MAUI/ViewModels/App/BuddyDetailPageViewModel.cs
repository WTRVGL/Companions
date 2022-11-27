using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Models.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.ViewModels.App
{
    [QueryProperty("Buddy","Buddy")]
    public partial class BuddyDetailPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Buddy _buddy;

        public BuddyDetailPageViewModel()
        {
        }


        [RelayCommand]
        async void GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        partial void OnBuddyChanged(Buddy buddy)
        {
        }
    }

}
