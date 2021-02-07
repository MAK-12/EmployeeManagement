using EmployeeManagement.Infra.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> CreateEmployee(Employee emp);
        Task<Employee> UpdateEmployee(Employee emp);
        Task<bool> DeleteEmployee(int id); 
        Task<Employee> GetEmployeeById(int id);
        
    }
}