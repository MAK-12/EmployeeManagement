using System;
using System.Collections.Generic;

namespace EmployeeManagement.Infra.Models
{
    public partial class Roles
    {
        public Roles()
        {
            EmployeeRole = new HashSet<EmployeeRole>();
        }

        public int RoleId { get; set; }
        public string Role { get; set; }
        public string RoleDescription { get; set; }

        public virtual ICollection<EmployeeRole> EmployeeRole { get; set; }
    }
}
