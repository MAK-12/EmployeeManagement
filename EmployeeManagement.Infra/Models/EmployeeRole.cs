using System;
using System.Collections.Generic;

namespace EmployeeManagement.Infra.Models
{
    public partial class EmployeeRole
    {
        public EmployeeRole()
        {
            EmployeeSalary = new HashSet<EmployeeSalary>();
        }

        public int EmployeeRoleId { get; set; }
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Roles Role { get; set; }
        public virtual ICollection<EmployeeSalary> EmployeeSalary { get; set; }
    }
}
