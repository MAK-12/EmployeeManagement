using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.ViewModels
{
    public class EmployeeTasksViewModel
    {
        public int EmployeeTaskId { get; set; }
        public int EmployeeId { get; set; }
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Please enter Total No Of Hours.")]
        [Display(Name = "Total No Of Hours")]
        public int TotalNoOfHours { get; set; }
        [Display(Name = "TCurrent Date")]
        public DateTime? CurrentDate { get; set; }
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        public string Priority { get; set; }

        [Display(Name = "Pay Per Task")]
        public decimal? PayPerTask { get; set; }
        public virtual EmployeeViewModel Employee { get; set; }
        public virtual Task Task { get; set; }
    }
}
