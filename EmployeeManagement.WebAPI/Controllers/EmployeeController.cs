using EmployeeManagement.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using EmployeeManagement.Infra.Models;

namespace EmployeeManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;
        private IUnitOfWork _unitOfWork;

        public EmployeeController(ILogger<EmployeeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _unitOfWork.Employee.GetAll();
            return this.Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var employeeDetail = await _unitOfWork.Employee.Get(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            return this.Ok(employeeDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Employee employee)
        {
            employee.FirstName = "test";
            _unitOfWork.Employee.Add(employee);
            await this._unitOfWork.SaveChangesAsync();

            return  this.Ok(employee);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, Employee employee)
        {
            var existingEmployeeDetail = await _unitOfWork.Employee.Get(id);
            if (existingEmployeeDetail == null)
            {
                return NotFound();
            }

            _unitOfWork.Employee.Update(employee);
            await this._unitOfWork.SaveChangesAsync();

            return this.Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var existingEmployeeDetail = await _unitOfWork.Employee.Get(id);
            if (existingEmployeeDetail == null)
            {
                return NotFound();
            }

            _unitOfWork.Employee.Delete(existingEmployeeDetail);
            await this._unitOfWork.SaveChangesAsync();

            return this.Ok(true);
        }
    }
}
