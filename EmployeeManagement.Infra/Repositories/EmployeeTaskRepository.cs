using EmployeeManagement.Infra.Models;
using EmployeeManagement.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTaskManagement.Infra.Repositories
{
    public class EmployeeTaskRepository : GenericRepository<EmployeeTask>, IEmployeeTaskRepository
    {
        public EmployeeTaskRepository(DBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EmployeeTask>> Find(string searchText)
        {
            return await this._context.Set<EmployeeTask>()
                .AsQueryable()
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public override async Task<IEnumerable<EmployeeTask>> GetAll()
        {
            return await this._context.Set<EmployeeTask>()
                .Include(x => x.Employee).ThenInclude(x => x.Role)
                .Include(x => x.Task)
                .AsQueryable()
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
