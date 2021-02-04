using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.ViewModels
{
    public class EmployeeRoleViewModel
    {
        public int EmployeeRoleId { get; set; }
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }

        public virtual EmployeeViewModel Employee { get; set; }
        public virtual RoleViewModel RoleViewModel { get; set; }
        public List<EmployeeSalariesViewModel> EmployeeSalariesViewModel { get; set; }
    }
}
