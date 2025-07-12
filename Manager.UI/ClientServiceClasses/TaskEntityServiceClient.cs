using System.Net.Http.Json;
using TaskManager.Contracts;
using TaskManager.Domain;

namespace Manager.UI.ClientServiceClasses
{
    public class TaskEntityServiceClient
    {
        private readonly HttpClient httpClient;
        public TaskEntityServiceClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<bool> CreateTask(TaskRequest request)
        {
            var create = await httpClient.PostAsJsonAsync("api/Task/createTask", request);
            return create.IsSuccessStatusCode;
        }

        public async Task<List<TaskEntity>> GetTask(string email)
        {
            var responce = await httpClient.GetAsync("api/Task/prioritetTask");
            if (responce.IsSuccessStatusCode)
                return new List<TaskEntity>();
            var task = await responce.Content.ReadFromJsonAsync<List<TaskEntity>>();
            return task ?? new List<TaskEntity>();
        }
    }
}
