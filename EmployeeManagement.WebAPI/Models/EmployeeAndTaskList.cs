using System.Collections.Generic;
using EmployeeManagement.Infra.Models;

namespace EmployeeManagementPortal.WebAPI.Models
{
    public class EmployeeAndTaskList
    {
        public IEnumerable<Employee> Employees;
        public IEnumerable<WorkItem> WorkItems;
    }
}
