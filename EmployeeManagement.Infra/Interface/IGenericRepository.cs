using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Infra.Repositories
{

    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> GetAll();
        //Task Add(T entity);
        Task<int> Delete(int id);
        // Task<int> Update(T entity);
        T Add(T entity);
        T Update(T entity);
    }
}
