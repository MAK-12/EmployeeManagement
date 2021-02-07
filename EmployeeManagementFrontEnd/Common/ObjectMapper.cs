using EmployeeManagement.Infra.Models;
using EmployeeManagementPortal.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.Common
{
    public class ObjectMapper:IObjectMapper
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
    }
}
