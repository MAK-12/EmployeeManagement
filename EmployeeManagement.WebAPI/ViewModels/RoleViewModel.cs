using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.WebAPI.ViewModels
{
    public class RoleViewModel
    {
        public int RoleId { get; set; }
        public string Role { get; set; }
        public string RoleDescription { get; set; }
        public List<EmployeeRoleViewModel> EmployeeRoleViewModel { get; set; }
    }
}
