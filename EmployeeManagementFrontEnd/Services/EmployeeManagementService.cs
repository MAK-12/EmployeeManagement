using EmployeeManagement.Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
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
            var response = await Client.GetAsync(
                "/employee");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <IEnumerable<Employee>>(responseStream);
        }
    }
}
