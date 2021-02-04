using System;
using System.Collections.Generic;

namespace EmployeeManagement.MVC.Entities
{
    public class EmployeeSalary
    {
        public int EmployeeSalaryId { get; set; }
        public int EmployeeRoleId { get; set; }
        public int PayperHour { get; set; }
        public decimal Salary { get; set; }
        public DateTime? PaytillDate { get; set; }
    
        public virtual EmployeeRole EmployeeRole { get; set; }
    }
}
