using EmployeeManagementPortal.MVC.Entities;
using EmployeeManagementPortal.MVC.ViewModels;
using System.Collections.Generic;

namespace EmployeeManagementPortal.MVC.Common
{
    public interface IObjectMapper
    {
        EmployeeViewModel EmployeeToEmployeeViewModel(EmployeeManagement.Infra.Models.Employee dto);

        EmployeeManagement.Infra.Models.Employee EmployeeViewModelToEmployee(EmployeeViewModel employeeViewModel);

        EmployeeTasksViewModel EmployeeTaskToEmployeeTasksViewModel(EmployeeTask dto);

        EmployeeTask EmployeeTasksViewModelToEmployeeTasks(EmployeeTasksViewModel employeeTasksViewModel);

       
        EmployeeTasksViewModel MapemployeesAndworkItemstoViewModel(IEnumerable<EmployeeAndTaskList> employeeAndTaskList);
    }
}
