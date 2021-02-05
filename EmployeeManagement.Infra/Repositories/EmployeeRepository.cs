using EmployeeManagement.WebAPI.Models;

namespace EmployeeManagement.Infra.Repositories
{
    public class EmployeeRepository : GenericRepository<Grade>, IEmployeeRepository
    {
        public EmployeeRepository(LearnNowContext context) : base(context)
        {

        }
    }
}
