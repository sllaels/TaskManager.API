using Blazored.LocalStorage;
using System.Net.Http;
using System.Net.Http.Headers;
namespace Manager.UI.ClientServiceClasses
{
    public class WorkWithToken
    {
        private readonly HttpClient httpClient;
        public WorkWithToken(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
       public void SetJwtToken(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

       public async Task TrySetTokenFromStorage(ILocalStorageService localStorage)
        {

            var token = await localStorage.GetItemAsync<string>("AuthToken");
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            else if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Токен не найден");
            }
        }
    }
}
