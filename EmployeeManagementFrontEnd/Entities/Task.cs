using System;
using System.Collections.Generic;

namespace EmployeeManagement.MVC.Entities
{
    public class Task
    {
       public int TaskId { get; set; }
        public string Name { get; set; }
        public int NoOfHours { get; set; }
        public bool? IsCompleted { get; set; }
    
        public virtual ICollection<EmployeeTask> EmployeeTasks { get; set; }
    }
}
