using EmployeeManagement.Infra.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Infra.Repositories
{
    public interface IWorkItemRepository : IGenericRepository<WorkItem>
    {
        Task<IEnumerable<WorkItem>> Find(string searchText);
    }
}
