using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Infra.Models;


namespace EmployeeManagementPortal.MVC.Services
{
    public interface IEmployeeTaskService
    {
        Task<IEnumerable<EmployeeTask>> GetEmployeeTasks();
        Task<EmployeeTask> CreateEmployeeTask(EmployeeTask empTask);
        Task<EmployeeTask> UpdateEmployeeTask(EmployeeTask empTask);
        Task<bool> DeleteEmployeeTask(int id);
        Task<EmployeeTask> GetEmployeeTaskById(int id);

        Task<EmployeeTask> GetEmpHourCapacityOfTheDate(int id, DateTime startDate, DateTime? endDate);

        Task<IEnumerable<EmployeeTask>> GetEmployeesAndWorkItems(String searchText);
    }
}
