using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Infra.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }
        IEmployeeTaskRepository EmployeeTaskRepository { get; }
        IWorkItemRepository TaskRepository { get; }
        int Complete();
        Task SaveChangesAsync();
    }
}
