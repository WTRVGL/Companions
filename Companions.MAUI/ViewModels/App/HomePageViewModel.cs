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
    public partial class HomePageViewModel : BaseViewModel, IRecipient<AppointmentDeletedMessage>
    {
        private readonly IBuddyService _buddyService;
        private readonly IConfiguration _config;

        public HomePageViewModel(IBuddyService buddyservice, IConfiguration config)
        {
            _buddyService = buddyservice;
            _config = config;

            WeakReferenceMessenger.Default.Register<AppointmentDeletedMessage>(this);

            _buddies = _buddyService.GetBuddies();

            _appointments = new ObservableCollection<Appointment>()
            {
                new Appointment {
                    Id = "1",
                    AppointmentName = "CPV Vaccinatie",
                    BuddyName = "Ori",
                    AppointmentType = "Dierenarts",
                    AppointmentDate = new DateTime(2022,12,24,15,30,00),
                    Description = "Tweede herhalingsprik voor CPV. Nog één vaccinatiemoment vereist tot volledige immunisatie. Standaard checkup wordt ook uitgevoerd en voedingsschema wordt nagekeken. Gewichtsverlies zal gecheckt worden.",
                    BuddyURL = "https://i.imgur.com/UUzY06O.png",
                    LocationCoordinates = new Location(50.956659, 5.328609),
                    LocationName = "DAC Prinsenhof"
                },
                new Appointment {
                    Id = "2",
                    AppointmentName = "Jaarlijkse checkup",
                    AppointmentType = "Dierenarts",
                    BuddyName = "Bassie",
                    Description = "Routine checkup ter controle gewicht en voedings.",
                    AppointmentDate = new DateTime(2022,12,24,15,30,00),
                    LocationName = "DAC Prinsenhof",
                    LocationCoordinates = new Location(50.956659, 5.328609),
                    BuddyURL = "https://i.imgur.com/GJe4t90.jpg"
                },
            };
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

        public void Receive(AppointmentDeletedMessage message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var appointment = Appointments.Where(a => a.Id == message.Value).First();
                Appointments.Remove(appointment);
            });

            Refresh();
        }
    }
}
