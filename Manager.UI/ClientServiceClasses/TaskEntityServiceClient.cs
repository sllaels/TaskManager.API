using Blazored.LocalStorage;
using System.Net.Http.Json;
using TaskManager.Contracts;
using TaskManager.Domain;
using System.Net.Http.Headers;
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
     
        public async Task<List<TaskEntity>> GetTaskByDate()
        {
            var responce = await httpClient.GetAsync("api/Task/GetTasksByDate");
            if (!responce.IsSuccessStatusCode)
                return new List<TaskEntity>();
            var task = await responce.Content.ReadFromJsonAsync<List<TaskEntity>>();
            return task ?? new List<TaskEntity>();
        }
    
        public async Task<List<TaskEntity>> GetTasksPrioritet()
        {
            var responce = await httpClient.GetAsync("api/Task/prioritetTask");
            if (!responce.IsSuccessStatusCode)
                return new List<TaskEntity>();
            var task = await responce.Content.ReadFromJsonAsync<List<TaskEntity>>();
            return task ?? new List<TaskEntity>();
        }
    }
}
