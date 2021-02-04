using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.WebAPI.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Grade { get; }
        int Complete();
    }
}
