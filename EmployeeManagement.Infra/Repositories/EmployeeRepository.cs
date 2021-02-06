using EmployeeManagement.Infra.Models;

namespace EmployeeManagement.Infra.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DBContext context) : base(context)
        {

        }
    }
}
