using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.WebAPI.ViewModels
{
    public class EmployeeTasksViewModel
    {
        public int EmployeeTaskId { get; set; }
        public int EmployeeId { get; set; }
        public int TaskId { get; set; }
        public int TotalNoOfHours { get; set; }
        public DateTime? CurrentDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Priority { get; set; }

        public virtual EmployeeViewModel EmployeeViewModel { get; set; }
        public virtual Task Task { get; set; }
    }
}
