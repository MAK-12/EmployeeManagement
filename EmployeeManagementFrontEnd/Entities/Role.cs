using System;
using System.Collections.Generic;

namespace EmployeeManagement.MVC.Entities
{
    public class Role
    { 
    
        public int RoleId { get; set; }
        public string Role1 { get; set; }
        public string RoleDescription { get; set; } 
        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
    }
}
