using System.Net.Http.Json;
using Blazored.LocalStorage;
using TaskManager.Contracts;
using System.Net.Http.Headers;
using System.Security.AccessControl;

namespace Manager.UI.ClientServiceClasses
{
    public class UserServiceClient
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorageService;
        public UserServiceClient(HttpClient httpClient,ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
        }
        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            var response = await httpClient.PostAsJsonAsync("api/User/register", request);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> LoginAsync(LoginRequest request)
        {
            var response = await httpClient.PostAsJsonAsync("api/User/login", request);
            if (!response.IsSuccessStatusCode) { return false; }
            var json = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
           if( json != null && json.ContainsKey("token"))
           {
                var token=json["token"];
                await localStorageService.SetItemAsync("AuthToken", token);

                httpClient.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",token);
                return true;
           }
           return false;
        }
    }
}
