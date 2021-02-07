using EmployeeManagement.Infra.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Infra.Repositories
{
    public interface IRoleRepository : IGenericRepository<Roles>
    {
        Task<IEnumerable<Roles>> Find(string searchText);
    }
}
