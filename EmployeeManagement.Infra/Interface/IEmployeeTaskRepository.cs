using EmployeeManagement.Infra.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Infra.Repositories
{
    public interface IEmployeeTaskRepository : IGenericRepository<EmployeeTask>
    {
        Task<IEnumerable<EmployeeTask>> Find(string searchText);
    }
}
