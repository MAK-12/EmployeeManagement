using EmployeeManagementPortal.MVC.Entities;
using EmployeeManagementPortal.MVC.ViewModels;
using System.Collections.Generic;

namespace EmployeeManagementPortal.MVC.Common
{
    public interface IObjectMapper
    {
        EmployeeViewModel EmployeeToEmployeeViewModel(Employee dto);

        Employee EmployeeViewModelToEmployee(EmployeeViewModel employeeViewModel);

        EmployeeTasksViewModel EmployeeTaskToEmployeeTasksViewModel(EmployeeTask dto);

        EmployeeTask EmployeeTasksViewModelToEmployeeTasks(EmployeeTasksViewModel employeeTasksViewModel); 
       
        EmployeeTasksViewModel MapemployeesAndworkItemstoViewModel(IEnumerable<EmployeeAndTaskList> employeeAndTaskList);
    }
}
