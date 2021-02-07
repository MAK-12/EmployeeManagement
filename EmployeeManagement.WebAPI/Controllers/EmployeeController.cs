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
            var employees = await _unitOfWork.EmployeeRepository.GetAll();
            return this.Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var employeeDetail = await _unitOfWork.EmployeeRepository.Get(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            return this.Ok(employeeDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Add(employee);
            await this._unitOfWork.SaveChangesAsync();

            return  this.Ok(employee);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, Employee employee)
        {
            var existingEmployeeDetail = await _unitOfWork.EmployeeRepository.Get(id);
            if (existingEmployeeDetail == null)
            {
                return NotFound();
            }

            existingEmployeeDetail.FirstName = employee.FirstName;
            existingEmployeeDetail.AccessCode = employee.AccessCode;
            existingEmployeeDetail.EmailAddress = employee.EmailAddress;
            existingEmployeeDetail.EmployeeCode = employee.EmployeeCode;
            existingEmployeeDetail.MobileNo = employee.MobileNo;
            existingEmployeeDetail.Surname = employee.Surname;
            existingEmployeeDetail.MiddleName = employee.MiddleName;
            existingEmployeeDetail.PhysicalAddress = employee.PhysicalAddress;
            existingEmployeeDetail.RoleId = 1;

            _unitOfWork.EmployeeRepository.Update(existingEmployeeDetail);
            await this._unitOfWork.SaveChangesAsync();

            return this.Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var existingEmployeeDetail = await _unitOfWork.EmployeeRepository.Get(id);
            if (existingEmployeeDetail == null)
            {
                return NotFound();
            }

            _unitOfWork.EmployeeRepository.Delete(existingEmployeeDetail);
            await this._unitOfWork.SaveChangesAsync();

            return this.Ok(true);
        }
    }
}
