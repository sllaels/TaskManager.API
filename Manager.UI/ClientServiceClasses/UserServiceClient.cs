using System.Net.Http.Json;
using TaskManager.Contracts;

namespace Manager.UI.ClientServiceClasses
{
    public class UserServiceClient
    {
        private HttpClient httpClient;

        public UserServiceClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            var response = await httpClient.PostAsJsonAsync("api/User/register", request);
            return response.IsSuccessStatusCode;
        }
        public async Task<string?> LoginAsync(RegisterRequest request)
        {
            var response = await httpClient.PostAsJsonAsync("api/User/login", request);
            if (!response.IsSuccessStatusCode) { return null; }
            var json = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
            return json != null && json.ContainsKey("token") ? json["token"] : null;
        }
    }
}
