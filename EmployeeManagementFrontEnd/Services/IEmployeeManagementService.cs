using EmployeeManagement.Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.Services
{
    public interface IEmployeeManagementService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> CreateEmployee(Employee emp);
        Task<Employee> UpdateEmployee(Employee emp);
        Task<bool> DeleteEmployee(int id); 
        Task<Employee> GetEmployeeById(int id);
        
    }
}