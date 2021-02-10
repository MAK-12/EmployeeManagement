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
                PhysicalAddress = dto.PhysicalAddress
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
                RoleId = employeeViewModel.RoleId,
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

        public IEnumerable<EmployeeTasksViewModel> EmployeeTasksDTOObjectsToViewModel(IEnumerable<EmployeeTask> employeeTasksList, IEnumerable<Employee> employeesList, IEnumerable<WorkItem> workItemsList)
        {
            return employeeTasksList.Select(e => new EmployeeTasksViewModel()
            {
                EmployeeTaskId = e.EmployeeTaskId,
                TaskId = e.TaskId,
                EmployeeName = employeesList.Where(x => x.EmployeeId == e.EmployeeId).Select(x => x.FirstName + " " + x.Surname).FirstOrDefault().ToString(),
                TaskName = workItemsList.Where(x => x.TaskId == e.TaskId).Select(x => x.Name).FirstOrDefault().ToString(),
                EmployeeId = e.EmployeeId,
                TotalNoOfHours = e.TotalNoOfHours,
                CurrentDate = e.CurrentDate,
                Priority = e.Priority,
                PayPerTask = e.PayPerTask
            });
        }

        //Delete Later
        public EmployeeTasksViewModel ListOfEmployeesAndTaskstoViewModelforDropDown(IEnumerable<Employee> emp, IEnumerable<WorkItem> workItem)
        {
            return new EmployeeTasksViewModel()
            {
                Employees = emp,
                WorkItems = workItem,
            };
        }
    }
}
