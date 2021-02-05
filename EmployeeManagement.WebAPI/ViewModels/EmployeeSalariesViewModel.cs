using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.WebAPI.ViewModels
{
    public class EmployeeSalariesViewModel
    {
        public int EmployeeSalaryId { get; set; }
        public int EmployeeRoleId { get; set; }
        public int PayperHour { get; set; }
        public decimal Salary { get; set; }
        public DateTime? PaytillDate { get; set; }
        public virtual EmployeeRoleViewModel EmployeeRoleViewModel { get; set; }
    }
}
