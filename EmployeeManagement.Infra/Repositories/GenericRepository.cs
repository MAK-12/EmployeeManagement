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

        public async Task<T> Get(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        //public async Task Add(T entity)
        //{
        //    await _context.Set<T>().AddAsync(entity);
        //}

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<int> IGenericRepository<T>.Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual T Add(T entity)
        {
            return this._context
                .Add(entity)
                .Entity;
        }
    }
}
