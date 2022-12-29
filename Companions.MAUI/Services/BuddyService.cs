using CommunityToolkit.Maui.Core.Extensions;
using Companions.MAUI.Models.App;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Services
{
    public class BuddyService : IBuddyService
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiBaseURL;
        public BuddyService(IConfiguration config)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            _apiBaseURL = config.GetValue<string>("CompanionsAPIBaseURL");
        }

        public async Task<Buddy> GetBuddyById(string id)
        {
            var res = await _httpClient.GetAsync(_apiBaseURL);
            var buddy = res.Content.ReadFromJsonAsync<Buddy>();

            // //
            return new Buddy();

        }

        public async Task<Buddy> AddBuddy(Buddy buddy)
        {
            var res = await _httpClient.PostAsJsonAsync($"{_apiBaseURL}/api/buddy", buddy);

            var buddies = await res.Content.ReadFromJsonAsync<List<Buddy>>();
            //
            return new Buddy();
        }

        public bool DeleteBuddy(string id)
        {
            return false;
        }

        public async Task<ObservableCollection<Buddy>> GetBuddies()
        {
            var res = await _httpClient.GetAsync($"{_apiBaseURL}/api/Buddies");
            var buddies = await res.Content.ReadFromJsonAsync<List<Buddy>>();
            return buddies.ToObservableCollection();
        }



        public Buddy UpdateBuddy(Buddy buddy)
        {
            throw new NotImplementedException();
        }
    }
}
