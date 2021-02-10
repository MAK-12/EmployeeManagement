using EmployeeManagementPortal.MVC.Entities;
using EmployeeManagementPortal.MVC.ViewModels;
using System.Collections.Generic;

namespace EmployeeManagementPortal.MVC.Common
{
    public interface IObjectMapper
    {
        EmployeeViewModel EmployeeToEmployeeViewModel(Employee employeeEntity);

        Employee EmployeeViewModelToEmployee(EmployeeViewModel employeeViewModel);

        EmployeeTasksViewModel EmployeeTaskToEmployeeTasksViewModel(EmployeeTask employeeTaskEntity);

        EmployeeTask EmployeeTasksViewModelToEmployeeTasks(EmployeeTasksViewModel employeeTasksViewModel);

        IEnumerable<EmployeeTasksViewModel> EmployeeTasksDTOObjectsToViewModel(IEnumerable<EmployeeTask> employeeTasksCollection, IEnumerable<Employee> employeesCollection, IEnumerable<WorkItem> workItemCollection);

        WorkItemViewModel WorkItemEnityToWorkItemViewModel(WorkItem workItemEnity);

        WorkItem WorkItemViewModelToWorkItemEnity(WorkItemViewModel workItemViewModel);

        RoleViewModel RoleEntityToRoleViewModel(Roles roleEntity);

        Roles RoleViewModelToRoleEntity(RoleViewModel roleViewModel);

    }
}
