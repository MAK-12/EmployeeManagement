using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementPortal.MVC.ViewModels
{
    public class EmployeeViewModel
    {
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; }

        [Required(ErrorMessage = "Please enter Firstname.")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Please enter Surname.")]
        public string Surname { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter Mobile Number.")]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"$|(^[\d ]*$)", ErrorMessage = "Mobile Number can only be numeric value.")]
        public string MobileNo { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
     
        public string PhysicalAddress { get; set; }

        [Required(ErrorMessage = "Please enter Access Code.")]
        public string AccessCode { get; set; }

        public string EmployeeRoleName{ get; set; }

        public int RoleId { get; set; } 
        public List<RoleViewModel> Role { get; set; }
    }
}
