using EmployeeManagementPortal.MVC.Entities;
using EmployeeManagementPortal.MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementPortal.MVC.Common
{
    public class ObjectMapper : IObjectMapper
    {

        public EmployeeViewModel EmployeeToEmployeeViewModel(Employee dto)
        {
            return new EmployeeViewModel()
            {
                FirstName = dto.FirstName,
                AccessCode = dto.AccessCode,
                EmailAddress = dto.EmailAddress,
                EmployeeCode = dto.EmployeeCode,
                EmployeeId = dto.EmployeeId,
                MobileNo = dto.MobileNo,
                Surname = dto.Surname,
                MiddleName = dto.MiddleName,
                PhysicalAddress = dto.PhysicalAddress,
            };
        }

        public Employee EmployeeViewModelToEmployee(EmployeeViewModel employeeViewModel)
        {
            return new Employee()
            {
                FirstName = employeeViewModel.FirstName,
                AccessCode = employeeViewModel.AccessCode,
                EmailAddress = employeeViewModel.EmailAddress,
                EmployeeCode = employeeViewModel.EmployeeCode,
                EmployeeId = employeeViewModel.EmployeeId,
                MobileNo = employeeViewModel.MobileNo,
                Surname = employeeViewModel.Surname,
                MiddleName = employeeViewModel.MiddleName,
                PhysicalAddress = employeeViewModel.PhysicalAddress,
                RoleId = 1,
            };
        }

        public EmployeeTasksViewModel EmployeeTaskToEmployeeTasksViewModel(EmployeeTask dto)
        {
            return new EmployeeTasksViewModel()
            {
                EmployeeTaskId = dto.EmployeeTaskId,
                EmployeeId = dto.EmployeeId,
                TaskId = dto.TaskId,
                TotalNoOfHours = dto.TotalNoOfHours,
                CurrentDate = dto.CurrentDate,
                Priority = dto.Priority,
                PayPerTask = dto.PayPerTask,
                EmployeeName = dto.Employee.FirstName + " " + dto.Employee.Surname,
                TaskName = dto.Task.Name,
            };
        }

        public EmployeeTask EmployeeTasksViewModelToEmployeeTasks(EmployeeTasksViewModel employeeTasksViewModel)
        {
            return new EmployeeTask()
            {
                EmployeeTaskId = employeeTasksViewModel.EmployeeTaskId,
                EmployeeId = employeeTasksViewModel.EmployeeId,
                TaskId = employeeTasksViewModel.TaskId,
                TotalNoOfHours = employeeTasksViewModel.TotalNoOfHours,
                CurrentDate = employeeTasksViewModel.CurrentDate,
                Priority = employeeTasksViewModel.Priority,
                PayPerTask = employeeTasksViewModel.PayPerTask,
            };
        }
        public EmployeeTasksViewModel MapemployeesAndworkItemstoViewModel(IEnumerable<EmployeeAndTaskList> employeeAndTaskList)
        {
            var empTasksViewModel = employeeAndTaskList.Select(e => new EmployeeTasksViewModel()
            {
                EmployeeList = (IEnumerable<EmployeeViewModel>)e.Employees,
                WorkItemList = (IEnumerable<WorkItemViewModel>)e.WorkItems,
            });

            return (EmployeeTasksViewModel)empTasksViewModel;
        }

    }
}
