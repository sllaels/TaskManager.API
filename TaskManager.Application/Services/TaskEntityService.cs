using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Interfaces;
using TaskManager.Contracts;
using TaskManager.Application.ServiceInterfaces;
using TaskManager.Domain;
using System.Net.Http.Json;

namespace TaskManager.Application.Services
{
    public class TaskEntityService:ITaskEntityService
    {
        private readonly HttpClient httpClient;
        public TaskEntityService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<bool> CreateTask(TaskRequest request)
        {
            var create=await httpClient.PostAsJsonAsync("api/Task/createTask",request);
            return create.IsSuccessStatusCode;
        }
    
        public async Task<List<TaskEntity>> GetTask(string email)
        {
            var responce = await httpClient.GetAsync("api/Task/prioritetTask");
            if (responce.IsSuccessStatusCode)
                return new List<TaskEntity>();
            var task= await responce.Content.ReadFromJsonAsync<List<TaskEntity>>();
            return task ?? new List<TaskEntity>();
        }
    }
 
}
