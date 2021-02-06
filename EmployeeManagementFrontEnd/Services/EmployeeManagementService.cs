using EmployeeManagement.Infra.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.Services
{
    public class EmployeeManagementService: IEmployeeManagementService
    {
        public HttpClient Client { get; }

        public EmployeeManagementService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44341/employee");

            Client = client;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var response = await Client.GetAsync("/employee");
            var responseStream = await response.Content.ReadAsStringAsync();
            var r = JsonConvert.DeserializeObject<List<Employee>>(responseStream);
            return r;
        }

        public async Task<Employee> CreateEmployee(Employee emp)
        {
            var json = JsonConvert.SerializeObject(emp);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(
                "/employee", data);



            var responseStream = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Employee>(responseStream);
        }
    }
}
