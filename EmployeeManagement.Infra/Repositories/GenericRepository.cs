using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Infra.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly LearnNowContext _context;
        public GenericRepository(LearnNowContext context)
        {
            _context = context;
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }


        public virtual T Add(T entity)
        {
            return this._context
                .Add(entity)
                .Entity;
        }

        public virtual T Update(T entity)
        {
            return this._context
                .Add(entity)
                .Entity;
        }

        public virtual T Delete(T entity)
        {
            this._context.Attach(entity);
            return this._context.Remove(entity).Entity;
        }
    }
}
