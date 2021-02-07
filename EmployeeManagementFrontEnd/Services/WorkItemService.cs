using EmployeeManagement.Infra.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeManagementPortal.MVC.Services
{
    public class WorkItemService : IWorkItemService
    {
        public HttpClient Client { get; }

        public WorkItemService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44341/WorkItem");

            Client = client;
        }

        public async Task<IEnumerable<WorkItem>> GetWorkItems()
        {
            var response = await Client.GetAsync("/WorkItem");
            var responseStream = await response.Content.ReadAsStringAsync();
            var r = JsonConvert.DeserializeObject<List<WorkItem>>(responseStream);
            return r;
        }

        public async Task<WorkItem> CreateWorkItem(WorkItem emp)
        {
            var json = JsonConvert.SerializeObject(emp);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(
                "/WorkItem", data);



            var responseStream = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WorkItem>(responseStream);
        }

        public async Task<WorkItem> UpdateWorkItem(WorkItem emp)
        {
            var json = JsonConvert.SerializeObject(emp);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PatchAsync($"/WorkItem/{emp.TaskId}", data);

            var responseStream = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WorkItem>(responseStream);
        }

        public async Task<bool> DeleteWorkItem(int id)
        {
            var response = await Client.DeleteAsync($"/WorkItem/{id}");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public async Task<WorkItem> GetWorkItemById(int id)
        {
            var response = await Client.GetAsync($"/WorkItem/{id}");
            var responseStream = await response.Content.ReadAsStringAsync();
            var r = JsonConvert.DeserializeObject<WorkItem>(responseStream);
            return r;
        }
    }
}