using EmployeeManagement.Infra.Models;
using System.Collections.Generic;
using System.Threading.Tasks; 

namespace EmployeeManagementPortal.MVC.Services
{
    public interface IRolesService
    {
        Task<IEnumerable<Roles>> GetRoles();
        Task<Roles> CreateRole(Roles emp);
        Task<Roles> UpdateRole(Roles emp);
        Task<bool> DeleteRole(int id);
        Task<Roles> GetRoleById(int id);
    }
}
