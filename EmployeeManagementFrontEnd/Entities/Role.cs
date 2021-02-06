using System;
using System.Collections.Generic;

namespace EmployeeManagement.MVC.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public decimal? RatePerhour { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
