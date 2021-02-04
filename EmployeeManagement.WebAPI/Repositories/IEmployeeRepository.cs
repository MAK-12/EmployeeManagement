using EmployeeManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.WebAPI.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Grade>
    {
    }
}
