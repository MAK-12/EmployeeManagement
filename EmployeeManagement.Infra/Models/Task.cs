﻿using System;
using System.Collections.Generic;

namespace EmployeeManagement.Infra.Models
{
    public partial class Task
    {
        public Task()
        {
            EmployeeTask = new HashSet<EmployeeTask>();
        }

        public int TaskId { get; set; }
        public string Name { get; set; }
        public int NoOfHours { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<EmployeeTask> EmployeeTask { get; set; }
    }
}
