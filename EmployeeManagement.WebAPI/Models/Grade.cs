using System;

namespace EmployeeManagement.WebAPI.Models
{
    public partial class Grade
    {

        public Guid Id { get; set; }
        public string GradeName { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
