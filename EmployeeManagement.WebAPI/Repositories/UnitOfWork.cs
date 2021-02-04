using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.WebAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LearnNowContext _context;
        public IEmployeeRepository Grade { get; }


        public UnitOfWork(LearnNowContext bookStoreDbContext,
            IEmployeeRepository booksRepository)
        {
            this._context = bookStoreDbContext;
            this.Grade = booksRepository;
        }
        public int Complete()
        {
            return _context.SaveChanges();
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
