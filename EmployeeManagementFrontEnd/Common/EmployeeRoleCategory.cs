using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.Common
{
    public enum EmployeeRoleCategory
    {
        [Display(Name = "Casual Employee Level 1")]
        CasualEmployeeLevel1 = 1,
        [Display(Name = "Casual Employee Level 2")]
        CasualEmployeeLevel2 = 2,
    }

}