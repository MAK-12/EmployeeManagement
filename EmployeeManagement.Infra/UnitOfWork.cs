using EmployeeTaskManagement.Infra.Repositories;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;
        private IEmployeeRepository employeeRepository;
        private IWorkItemRepository taskRepository;
        private IEmployeeTaskRepository employeeTaskRepository;


        public UnitOfWork(DBContext bookStoreDbContext)
        {
            this._context = bookStoreDbContext;
            //this.Employee = employeeRepository;
            //this.Task = taskRepository;
            //this.EmployeeTask = employeeTaskRepository;
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (this.employeeRepository == null)
                {
                    this.employeeRepository = new EmployeeRepository(this._context);
                }

                return this.employeeRepository;
            }
        }

        public IWorkItemRepository TaskRepository
        {
            get
            {
                if (this.taskRepository == null)
                {
                    this.taskRepository = new WorkItemRepository(this._context);
                }

                return this.taskRepository;
            }
        }

        public IEmployeeTaskRepository EmployeeTaskRepository
        {
            get
            {
                if (this.employeeTaskRepository == null)
                {
                    this.employeeTaskRepository = new EmployeeTaskRepository(this._context);
                }

                return this.employeeTaskRepository;
            }
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
