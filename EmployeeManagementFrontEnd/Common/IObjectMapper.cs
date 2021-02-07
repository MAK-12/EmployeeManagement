using EmployeeManagement.Infra.Models;
using EmployeeManagementPortal.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.Common
{
    public interface IObjectMapper
    {
        EmployeeViewModel EmployeeToEmployeeViewModel(Employee dto);

        Employee EmployeeViewModelToEmployee(EmployeeViewModel employeeViewModel);
    }
}
