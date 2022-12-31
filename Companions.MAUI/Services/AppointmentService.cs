using CommunityToolkit.Maui.Core.Extensions;
using Companions.MAUI.Models.App;
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

        public Appointment AddAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<Appointment>> GetAppointments()
        {
            await EnsureAuthHeaders();

            var res = await _httpClient.GetAsync($"{_apiBaseURL}/api/Appointments");
            var appointments = await res.Content.ReadFromJsonAsync<List<Appointment>>();
            return appointments
                .Where(a => a.AppointmentDate > DateTime.Now)
                .OrderBy(a => a.AppointmentDate)
                .ToObservableCollection();
        }

        public ObservableCollection<SchedulerAppointment> GetSchedulerAppointments()
        {
            return null;
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
