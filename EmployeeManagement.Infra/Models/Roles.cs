using System;
using System.Collections.Generic;

namespace EmployeeManagement.Infra.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Employee = new HashSet<Employee>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public decimal? RatePerhour { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
