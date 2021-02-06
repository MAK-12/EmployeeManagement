using EmployeeManagement.Infra.Models;
using EmployeeManagement.Infra.Repositories;

namespace EmployeeTaskManagement.Infra.Repositories
{
    public class EmployeeTaskRepository : GenericRepository<EmployeeTask>, IEmployeeTaskRepository
    {
        public EmployeeTaskRepository(DBContext context) : base(context)
        {

        }
    }
}
