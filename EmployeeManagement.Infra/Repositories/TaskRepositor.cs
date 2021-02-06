using EmployeeManagement.Infra.Models;

namespace EmployeeManagement.Infra.Repositories
{
    public class TaskRepository : GenericRepository<Task>, ITaskRepository
    {
        public TaskRepository(DBContext context) : base(context)
        {

        }
    }
}
