using EmployeeManagement.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using EmployeeManagement.Infra.Models;
using EmployeeManagementPortal.WebAPI.Models;

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

        [HttpGet("search/{empId}")]
        public async Task<IActionResult> GetEmpHourCapacityOfTheDate(int empId, DateTime date)
        {
            var empTasks = await _unitOfWork.EmployeeTaskRepository.FindAsync(empTask => empTask.EmployeeId == empId && empTask.CurrentDate == date);
            return this.Ok(empTasks);
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

        [HttpGet("search")]
        public async Task<IActionResult> Search(String searchText)
        {
            var employeeTasks = await _unitOfWork.EmployeeTaskRepository.Find(searchText);
            return this.Ok(employeeTasks);
        }

        [HttpGet("employees-tasks")]
        public async Task<IActionResult> GetEmployeesAndWorkItems(String searchText)
        {
            var employees = await _unitOfWork.EmployeeRepository.GetAll();
            var tasks = await _unitOfWork.TaskRepository.GetAll();
            var employeesAndTasks = new EmployeeAndTaskList()
            {
                Employees = employees,
                WorkItems = tasks,
            };
            return this.Ok(employeesAndTasks);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeTask employee)
        {
            _unitOfWork.EmployeeTaskRepository.Add(employee);
            await this._unitOfWork.SaveChangesAsync();

            return  this.Ok(employee);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, EmployeeTask employeeTask)
        {
            var existingEmployeeTaskDetail = await _unitOfWork.EmployeeTaskRepository.Get(id);
            if (existingEmployeeTaskDetail == null)
            {
                return NotFound();
            }

            existingEmployeeTaskDetail.TaskId = employeeTask.TaskId;
            existingEmployeeTaskDetail.EmployeeId = employeeTask.EmployeeId;
            existingEmployeeTaskDetail.TotalNoOfHours = employeeTask.TotalNoOfHours;
            existingEmployeeTaskDetail.CurrentDate = employeeTask.CurrentDate;
            existingEmployeeTaskDetail.Priority = employeeTask.Priority;
            existingEmployeeTaskDetail.PayPerTask = employeeTask.PayPerTask;

            _unitOfWork.EmployeeTaskRepository.Update(existingEmployeeTaskDetail);
            await this._unitOfWork.SaveChangesAsync();

            return this.Ok(existingEmployeeTaskDetail);
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
