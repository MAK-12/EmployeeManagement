using EmployeeManagement.Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.WebAPI.Models
{
    public class EmployeeAndTaskList
    {
        public IEnumerable<Employee> Employees;
        public IEnumerable<WorkItem> WorkItems;
    }
}
