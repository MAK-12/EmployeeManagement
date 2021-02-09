using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.ViewModels
{
    public class EmployeesTotalHoursPerDayViewModel
    {
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }

        public string FullName { get; set; }


        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Display(Name = "Total Hours")]
        public int TotalHours { get; set; }
    }
}
