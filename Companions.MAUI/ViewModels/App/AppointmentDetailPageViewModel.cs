using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Companions.Domain;
using Companions.MAUI.Messages;
using Companions.MAUI.Models.App;
using Companions.MAUI.Views.App;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointment = Companions.MAUI.Models.App.Appointment;

namespace Companions.MAUI.ViewModels.App
{
    [QueryProperty("Appointment", "Appointment")]
    public partial class AppointmentDetailPageViewModel : BaseViewModel
    {

        public AppointmentDetailPageViewModel()
        {
        }

        [ObservableProperty]
        private Appointment _appointment;

        [ObservableProperty]
        private bool _isReady;

        [ObservableProperty]
        private ObservableCollection<Place> _bindablePlaces;

        [RelayCommand]
        async void AppointmentSettings()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Change appointment", "Cancel", null, "Edit appointment", "Delete appointment");
            if(action == "Delete appointment")
            {
                var secondAction = await Application.Current.MainPage.DisplayActionSheet("Are you sure?", "Cancel", null, "Delete appointment");
                if (secondAction == "Delete appointment"){
                    //Api Call to delete appointment.

                    //Send deleted event.
                    WeakReferenceMessenger.Default.Send(new AppointmentDeletedMessage(Appointment.Id));
                    //Go back to main menu.
                    
                    GoBack();
                }
            }

            if(action == "Edit appointment")
            {

                await Shell.Current.GoToAsync(nameof(EditAppointmentPage),
                new Dictionary<string, object>
                {
                    {"Appointment",Appointment }
                });
            }
        }

        [RelayCommand]
        async void GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        async void OpenMapsApp()
        {
            var location = Appointment.Place.Location;
            var options = new MapLaunchOptions { Name = Appointment.Place.Name };

            try
            {
                await Map.Default.OpenAsync(location, options );
                ;
            }
            catch (Exception ex)
            {
                // No map application available to open
            }

            if (await Map.Default.TryOpenAsync(location, options) == false)
            {
                // Map failed to open
            }
        }

       partial void OnAppointmentChanged(Appointment appointment)
        {
            var places = new List<Place>
            {
                new Place { Location = appointment.Place.Location }
            };

            BindablePlaces = new ObservableCollection<Place>(places);
            IsReady = true;
        }

    }
}
