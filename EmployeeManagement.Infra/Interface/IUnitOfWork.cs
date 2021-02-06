using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Infra.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employee { get; }
        ITaskRepository Task { get; }
        int Complete();
        Task SaveChangesAsync();
    }
}
