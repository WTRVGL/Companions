using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Companions.MAUI.Messages;
using Companions.MAUI.Models.App;
using Companions.MAUI.Services;
using Companions.MAUI.Views.App;
using Companions.MAUI.Views.App.BuddyDetail;
using Microsoft.Extensions.Configuration;
using Syncfusion.Maui.ListView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemTappedEventArgs = Syncfusion.Maui.ListView.ItemTappedEventArgs;

namespace Companions.MAUI.ViewModels.App
{
    public partial class HomePageViewModel : BaseViewModel
    {
        private readonly IBuddyService _buddyService;
        private readonly IAppointmentService _appointmentService; 

        private readonly IConfiguration _config;

        public HomePageViewModel(IBuddyService buddyservice, IConfiguration config, IAppointmentService appointmentService)
        {
            _buddyService = buddyservice;
            _appointmentService = appointmentService;
            _config = config;

            _buddies = _buddyService.GetBuddies();
            _appointments = _appointmentService.GetAppointments();
            
        }


        [ObservableProperty]
        private bool _isRefreshing;

        [ObservableProperty]
        private ObservableCollection<Buddy> _buddies;

        [ObservableProperty]
        private ObservableCollection<Appointment> _appointments;

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

        [RelayCommand]
        async void OpenAppointmentDetail(ItemTappedEventArgs args)
        {
            var appointment = (Appointment)args.DataItem;

            await Shell.Current.GoToAsync(nameof(AppointmentDetailPage),
                new Dictionary<string, object>
                {
                    {"Appointment", appointment}
                });
        }

        [RelayCommand]
        async void PageAppearing()
        {
            Appointments = _appointmentService.GetAppointments();
        }

    }
}
