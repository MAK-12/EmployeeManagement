using EmployeeManagement.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.Infra.Models;

namespace EmployeeManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private IUnitOfWork _unitOfWork;

        public EmployeeController(ILogger<WeatherForecastController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _unitOfWork.Employee.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Employee> Get(Guid id)
        {
            return await _unitOfWork.Employee.Get(id);
        }

        [HttpGet("{id}")]
        public async Task<Employee> Post(Employee employee)
        {
            employee.FirstName = "test";
            _unitOfWork.Employee.Add(employee);
            await this._unitOfWork.SaveChangesAsync();

            return  employee;
        }
    }
}
