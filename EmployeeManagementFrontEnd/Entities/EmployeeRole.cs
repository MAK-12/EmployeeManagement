using System;
using System.Collections.Generic;

namespace EmployeeManagement.MVC.Entities
{
    public class EmployeeRole
    { 
        public int EmployeeRoleId { get; set; }
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<EmployeeSalary> EmployeeSalaries { get; set; }
    }
}
