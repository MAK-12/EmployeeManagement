using EmployeeManagement.Infra.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.Services
{
    public class RolesService : IRolesService
    {
        public HttpClient Client { get; }

        public RolesService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44341/Roles");

            Client = client;
        }

        public async Task<IEnumerable<Roles>> GetRoles()
        {
            var response = await Client.GetAsync("/Roles");
            var responseStream = await response.Content.ReadAsStringAsync();
            var r = JsonConvert.DeserializeObject<List<Roles>>(responseStream);
            return r;
        }

        public async Task<Roles> CreateRole(Roles emp)
        {
            var json = JsonConvert.SerializeObject(emp);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(
                "/Roles", data);



            var responseStream = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Roles>(responseStream);
        }

        public async Task<Roles> UpdateRole(Roles emp)
        {
            var json = JsonConvert.SerializeObject(emp);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PatchAsync($"/Roles/{emp.RoleId}", data);

            var responseStream = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Roles>(responseStream);
        }

        public async Task<bool> DeleteRole(int id)
        {
            var response = await Client.DeleteAsync($"/Roles/{id}");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public async Task<Roles> GetRoleById(int id)
        {
            var response = await Client.GetAsync($"/Roles/{id}");
            var responseStream = await response.Content.ReadAsStringAsync();
            var r = JsonConvert.DeserializeObject<Roles>(responseStream);
            return r;
        }
    }

}
