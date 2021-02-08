using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.ViewModels
{
    public class WorkItemViewModel
    {
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Please Enter Task Name.")]
        [Display(Name = "Task Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter No Of Hours.")]
        [Display(Name = "Task Duration")]
        public int NoOfHours { get; set; }

        [Display(Name = "Is Task(Work) Completed")]
        public bool? IsCompleted { get; set; }
        public List<EmployeeTasksViewModel> EmployeeTasks { get; set; }
    }
}
