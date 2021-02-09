using EmployeeManagement.Infra.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Infra.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> Find(string searchText);

        Task<Employee> GetEmployeeDetailsByaccessCode(string accessCode);
    }
}
