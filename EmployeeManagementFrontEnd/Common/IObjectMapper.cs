using EmployeeManagementPortal.MVC.Entities;
using EmployeeManagementPortal.MVC.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.Common
{
    public interface IObjectMapper
    {
        EmployeeViewModel EmployeeToEmployeeViewModel(Employee dto);

        Employee EmployeeViewModelToEmployee(EmployeeViewModel employeeViewModel);

        EmployeeTasksViewModel EmployeeTaskToEmployeeTasksViewModel(EmployeeTask dto);

        EmployeeTask EmployeeTasksViewModelToEmployeeTasks(EmployeeTasksViewModel employeeTasksViewModel);

        IEnumerable<EmployeeTasksViewModel> EmployeeTasksDTOObjectsToViewModel(IEnumerable<EmployeeTask> employeeTasksList, IEnumerable<Employee> employeesList, IEnumerable<WorkItem> workItemsList);

        EmployeeTasksViewModel ListOfEmployeesAndTaskstoViewModelforDropDown(IEnumerable<Employee> emp, IEnumerable<WorkItem> workItem);

    }
}
