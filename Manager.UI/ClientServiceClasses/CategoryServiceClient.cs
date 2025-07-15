using System.Net.Http.Json;
using TaskManager.Contracts;
using TaskManager.Domain;
using System.Net.Http.Headers;
namespace Manager.UI.ClientServiceClasses
{
    public class CategoryServiceClient
    {
        private readonly HttpClient _httpClient;

        public CategoryServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateCategory(CategoryRequest request)
        {
            var createCategory = await _httpClient.PostAsJsonAsync("api/Categories/createCategories", request);
            return createCategory.IsSuccessStatusCode;
        }
    }
}
