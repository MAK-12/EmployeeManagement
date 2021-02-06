using EmployeeManagement.Infra.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.Services
{
    //public class EmployeeTaskService :
    //    //IEmployeeTaskService
    //{
    //    public HttpClient Client { get; }

    //    public EmployeeTaskService(HttpClient client)
    //    {
    //        client.BaseAddress = new Uri("https://localhost:44341/employee");

    //        Client = client;
    //    }

    //    public async Task<IEnumerable<EmployeeTask>> GetEmployeeTasks()
    //    {
    //        var response = await Client.GetAsync("/task");
    //        var responseStream = await response.Content.ReadAsStringAsync();
    //        var r = JsonConvert.DeserializeObject<List<EmployeeManagement.Infra.Models.Task>>(responseStream);
    //        return r;
    //    }

    //    public async Task<Employee> CreateEmployee(Employee emp)
    //    {
    //        var json = JsonConvert.SerializeObject(emp);
    //        var data = new StringContent(json, Encoding.UTF8, "application/json");

    //        var response = await Client.PostAsync(
    //            "/employee", data);



    //        var responseStream = await response.Content.ReadAsStringAsync();
    //        return JsonConvert.DeserializeObject<Employee>(responseStream);
    //    }

    //    public async Task<Employee> UpdateEmployee(Employee emp)
    //    {
    //        var json = JsonConvert.SerializeObject(emp);
    //        var data = new StringContent(json, Encoding.UTF8, "application/json");

    //        var response = await Client.PatchAsync($"/employee/{emp.EmployeeId}", data);

    //        var responseStream = await response.Content.ReadAsStringAsync();
    //        return JsonConvert.DeserializeObject<Employee>(responseStream);
    //    }

    //    public async Task<bool> DeleteEmployee(int id)
    //    {
    //        var response = await Client.DeleteAsync($"/employee/{id}");
    //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
    //        {
    //            return true;
    //        }

    //        return false;
    //    }

    //    public async Task<Employee> GetEmployeeById(int id)
    //    {
    //        var response = await Client.GetAsync($"/employee/{id}");
    //        var responseStream = await response.Content.ReadAsStringAsync();
    //        var r = JsonConvert.DeserializeObject<Employee>(responseStream);
    //        return r;
    //    }
    //}
}
