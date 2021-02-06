﻿using System;
using System.Collections.Generic;

namespace EmployeeManagement.Infra.Models
{
    public partial class EmployeeTask
    {
        public int EmployeeTaskId { get; set; }
        public int EmployeeId { get; set; }
        public int TaskId { get; set; }
        public int TotalNoOfHours { get; set; }
        public DateTime? CurrentDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Priority { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Task Task { get; set; }
    }
}
