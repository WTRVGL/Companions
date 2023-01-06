using CommunityToolkit.Maui.Core.Extensions;
using Companions.MAUI.Models.App;
using Companions.MAUI.Services.Models;
using Microsoft.Extensions.Configuration;
using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiBaseURL;
        public AppointmentService(IConfiguration config)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            _apiBaseURL = config.GetValue<string>("CompanionsAPIBaseURL");
        }

        private async Task EnsureAuthHeaders()
        {
            //Check if headers present
            if (_httpClient.DefaultRequestHeaders.Authorization != null) return;

            var jwt = await SecureStorage.GetAsync("JWT");
            _httpClient.DefaultRequestHeaders.Add("Authorization", jwt);
        }

        public async Task<bool> DeleteAppointment(string id)
        {
            await EnsureAuthHeaders();

            var res = await _httpClient.DeleteAsync($"{_apiBaseURL}/api/Appointment/{id}");
            var deleted = await res.Content.ReadFromJsonAsync<bool>();

            return deleted;
        }

        public async Task<ObservableCollection<Appointment>> GetAppointments()
        {
            await EnsureAuthHeaders();

            var res = await _httpClient.GetAsync($"{_apiBaseURL}/api/Appointments");
            var appointments = await res.Content.ReadFromJsonAsync<List<Appointment>>();
            var sortedAppointments = appointments
                .Where(a => a.AppointmentDate > DateTime.Now)
                .OrderBy(a => a.AppointmentDate)
                .ToObservableCollection();

            return sortedAppointments;
        }

        public ObservableCollection<SchedulerAppointment> GetSchedulerAppointments()
        {
            return null;
        }

        public async Task<Appointment> UpdateAppointment(Appointment appointment)
        {
            await EnsureAuthHeaders();

            var req = new UpdateAppointmentRequest
            {
                Id = appointment.Id,
                AppointmentDate = appointment.AppointmentDate,
                AppointmentName = appointment.AppointmentName,
                BuddyId = appointment.BuddyId,
                Description = appointment.Description,
                PlaceId = appointment.Place.Id
            };


            var res = await _httpClient.PutAsJsonAsync<UpdateAppointmentRequest>($"{_apiBaseURL}/api/Appointment", req);
            var updatedAppointment = await res.Content.ReadFromJsonAsync<Appointment>();
            return updatedAppointment;
        }

        public async Task<Appointment> CreateAppointment(CreateAppointment appointment)
        {
            await EnsureAuthHeaders();


            var res = await _httpClient.PostAsJsonAsync<CreateAppointment>($"{_apiBaseURL}/api/Appointment", appointment);
            var updatedAppointment = await res.Content.ReadFromJsonAsync<Appointment>();
            return updatedAppointment;
        }
    }
}
