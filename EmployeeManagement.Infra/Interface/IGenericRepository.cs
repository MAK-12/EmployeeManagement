using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Infra.Repositories
{

    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
