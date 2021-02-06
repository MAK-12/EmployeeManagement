using EmployeeManagement.Infra.Models;

namespace EmployeeManagement.Infra.Repositories
{
    public class WorkItemRepository : GenericRepository<WorkItem>, IWorkItemRepository
    {
        public WorkItemRepository(DBContext context) : base(context)
        {

        }
    }
}
