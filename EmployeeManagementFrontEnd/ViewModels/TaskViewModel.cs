using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.ViewModels
{
    public class TaskViewModel
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public int NoOfHours { get; set; }
        public bool? IsCompleted { get; set; }
        public List<EmployeeTasksViewModel> EmployeeTasks { get; set; }
    }
}
