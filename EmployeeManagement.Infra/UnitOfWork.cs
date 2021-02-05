using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LearnNowContext _context;
        public IEmployeeRepository Employee { get; }
        public ITaskRepository Task { get; }


        public UnitOfWork(LearnNowContext bookStoreDbContext,
            IEmployeeRepository employeeRepository,
            ITaskRepository taskRepository)
        {
            this._context = bookStoreDbContext;
            this.Employee = employeeRepository;
            this.Task = taskRepository;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await this._context.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
