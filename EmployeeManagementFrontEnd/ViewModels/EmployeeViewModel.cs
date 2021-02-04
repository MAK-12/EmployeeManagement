using EmployeeManagementPortal.MVC.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementPortal.MVC.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"$|(^[\d ]*$)", ErrorMessage = "Mobile Number can only be numeric value.")]
        public string MobileNo { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        public string PhysicalAddress { get; set; }
        public string AccessCode { get; set; }
        public EmploymentType IsPermanentEmployee { get; set; }

        public List<EmployeeRoleViewModel> EmployeeRoleViewModel { get; set; }
        public List<EmployeeTasksViewModel> EmployeeTasksViewModel { get; set; }
    }
}
