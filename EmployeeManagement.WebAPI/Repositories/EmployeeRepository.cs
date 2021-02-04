using EmployeeManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.WebAPI.Repositories
{
    public class EmployeeRepository : GenericRepository<Grade>, IEmployeeRepository
    {
        public EmployeeRepository(LearnNowContext context) : base(context)
        {

        }
    }
}
