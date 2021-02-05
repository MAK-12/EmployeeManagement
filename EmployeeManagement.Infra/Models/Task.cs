using System;
using System.Collections.Generic;

namespace EmployeeManagement.Infra.Entities
{
     public class Task
     {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public int NoOfHours { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; } 
        public virtual ICollection<EmployeeTask> EmployeeTasks { get; set; }
    }
}