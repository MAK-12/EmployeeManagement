using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.Common
{
    public enum EmploymentType
    {
        [Display(Name = "Permanent Employee")]
        PermanentEmployee,
        [Display(Name = "Casual Employee")]
        CasualEmployee
    }

}