using EmployeeManagementPortal.MVC.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EmployeeManagementPortal.MVC.ViewModels
{
    public class EmployeeSalaryViewModel
    {

        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }

        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your secured Access Code.")]
        [Display(Name = "Access Code")]
        public string AccessCode { get; set; }
        public EmployeeRoleCategory EmployeeRoleCategory { get; set; }

        public string EmployeeRoleName { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        public int TotalNoOfHoursWorked { get; set; }

        public decimal Salary { get; set; }

        public int RoleId { get; set; } 
    }
}
