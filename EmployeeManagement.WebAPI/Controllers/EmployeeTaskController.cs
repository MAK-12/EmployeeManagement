using EmployeeManagement.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using EmployeeManagement.Infra.Models;

namespace EmployeeTaskManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeTaskController : ControllerBase
    {

        private readonly ILogger<EmployeeTaskController> _logger;
        private IUnitOfWork _unitOfWork;

        public EmployeeTaskController(ILogger<EmployeeTaskController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _unitOfWork.EmployeeTaskRepository.GetAll();
            return this.Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var employeeDetail = await _unitOfWork.EmployeeTaskRepository.Get(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            return this.Ok(employeeDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeTask employee)
        {
            _unitOfWork.EmployeeTaskRepository.Add(employee);
            await this._unitOfWork.SaveChangesAsync();

            return  this.Ok(employee);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, EmployeeTask employee)
        {
            var existingEmployeeTaskDetail = await _unitOfWork.EmployeeTaskRepository.Get(id);
            if (existingEmployeeTaskDetail == null)
            {
                return NotFound();
            }

            _unitOfWork.EmployeeTaskRepository.Update(employee);
            await this._unitOfWork.SaveChangesAsync();

            return this.Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var existingEmployeeTaskDetail = await _unitOfWork.EmployeeTaskRepository.Get(id);
            if (existingEmployeeTaskDetail == null)
            {
                return NotFound();
            }

            _unitOfWork.EmployeeTaskRepository.Delete(existingEmployeeTaskDetail);
            await this._unitOfWork.SaveChangesAsync();

            return this.Ok(true);
        }
    }
}
