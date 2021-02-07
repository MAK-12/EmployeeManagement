using EmployeeManagement.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using EmployeeManagement.Infra.Models;

namespace RoleManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("Roles")]
    public class RoleController : ControllerBase
    {

        private readonly ILogger<RoleController> _logger;
        private IUnitOfWork _unitOfWork;

        public RoleController(ILogger<RoleController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roles = await _unitOfWork.RoleRepository.GetAll();
            return this.Ok(roles);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(String searchText)
        {
            var roles = await _unitOfWork.RoleRepository.Find(searchText);
            return this.Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var roleDetail = await _unitOfWork.RoleRepository.Get(id);
            if (roleDetail == null)
            {
                return NotFound();
            }

            return this.Ok(roleDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Roles role)
        {
            _unitOfWork.RoleRepository.Add(role);
            await this._unitOfWork.SaveChangesAsync();

            return  this.Ok(role);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, Roles role)
        {
            var existingRoleDetail = await _unitOfWork.RoleRepository.Get(id);
            if (existingRoleDetail == null)
            {
                return NotFound();
            }

            existingRoleDetail.RoleName = role.RoleName;
            existingRoleDetail.RoleDescription = role.RoleDescription;
            existingRoleDetail.RatePerhour = role.RatePerhour;

            _unitOfWork.RoleRepository.Update(existingRoleDetail);
            await this._unitOfWork.SaveChangesAsync();

            return this.Ok(role);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var existingRoleDetail = await _unitOfWork.RoleRepository.Get(id);
            if (existingRoleDetail == null)
            {
                return NotFound();
            }

            _unitOfWork.RoleRepository.Delete(existingRoleDetail);
            await this._unitOfWork.SaveChangesAsync();

            return this.Ok(true);
        }
    }
}
