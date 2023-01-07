using Companions.MAUI.Models;
using Companions.MAUI.Services.Interface;
using Companions.MAUI.Views;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace Companions.MAUI
{
    public partial class App : Application
    {
        private readonly IAuthService _authService;
        private readonly string _apiAuthBaseURL;

        public App(IConfiguration config, IAuthService authService)
        {
            _authService = authService;
            _apiAuthBaseURL = config.GetValue<string>("CompanionsAuthBaseURL");
            InitializeComponent();
            MainPage = new BogusPage();
        }

        protected async override void OnStart()
        {
            var token = await SecureStorage.GetAsync("JWT");

            if (token == null)
            {
                MainPage = new LoginShell();
                base.OnStart();
                return;
            }


            var _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);

            User user;

            var res = await _httpClient.GetAsync($"{_apiAuthBaseURL}/api/Auth");

            if (res.StatusCode == HttpStatusCode.InternalServerError)
            {
                user = new User();
            }

            else
            {
                user = await res.Content.ReadFromJsonAsync<User>();
            }

            var userSerialized = JsonConvert.SerializeObject(user);
            Preferences.Set("User", userSerialized);
            MainPage = new MainShell();
            base.OnStart();

        }
    }
}

