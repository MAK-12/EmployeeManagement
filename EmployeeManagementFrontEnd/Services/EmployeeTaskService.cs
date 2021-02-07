using EmployeeManagement.Infra.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.Services
{
    public class EmployeeTaskService : IEmployeeTaskService
    {
        IConfiguration _configuration;
        public HttpClient Client { get; }

        public EmployeeTaskService(HttpClient client,IConfiguration configuration)
        {
            client.BaseAddress = new Uri(_configuration["BaseUrl"]);

            Client = client;
        }

        public async Task<IEnumerable<EmployeeTask>> GetEmployeeTasks()
        {
            var response = await Client.GetAsync("/EmployeeTask");
            var responseStream = await response.Content.ReadAsStringAsync();
            var r = JsonConvert.DeserializeObject<List<EmployeeTask>>(responseStream);
            return r;
        }

        public async Task<EmployeeTask> CreateEmployeeTask(EmployeeTask empTask)
        {
            var json = JsonConvert.SerializeObject(empTask);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(
                _configuration["EmployeeRelationURL"], data);



            var responseStream = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<EmployeeTask>(responseStream);
        }

        public async Task<EmployeeTask> UpdateEmployeeTask(EmployeeTask empTask)
        {
            var json = JsonConvert.SerializeObject(empTask);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PatchAsync(string.Concat(_configuration["EmployeeRelationURL"],"/",empTask.EmployeeTaskId), data);

            var responseStream = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<EmployeeTask>(responseStream);
        }

        public async Task<bool> DeleteEmployeeTask(int id)
        {
            var response = await Client.DeleteAsync($"/EmployeeTask/{id}");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public async Task<EmployeeTask> GetEmployeeTaskById(int id)
        {
            var response = await Client.GetAsync($"/EmployeeTask/{id}");
            var responseStream = await response.Content.ReadAsStringAsync();
            var r = JsonConvert.DeserializeObject<EmployeeTask>(responseStream);
            return r;
        }
    }
}
