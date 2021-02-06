using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.Infra.Models;
using EmployeeManagement.Infra.Repositories;

namespace TaskManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly ILogger<TaskController> _logger;
        private IUnitOfWork _unitOfWork;

        public TaskController(ILogger<TaskController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeManagement.Infra.Models.Task>> Get()
        {
            return await _unitOfWork.Task.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var taskDetail = await _unitOfWork.Task.Get(id);
            if (taskDetail == null)
            {
                return NotFound();
            }

            return this.Ok(taskDetail);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var taskDetail = await _unitOfWork.Task.Get(id);
            if (taskDetail == null)
            {
                return NotFound();
            }
            _unitOfWork.Task.Delete(taskDetail);
            await this._unitOfWork.SaveChangesAsync();

            return this.Ok(taskDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeManagement.Infra.Models.Task task)
        {
            _unitOfWork.Task.Add(task);
            await this._unitOfWork.SaveChangesAsync();

            return  this.Ok(task);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, EmployeeManagement.Infra.Models.Task task)
        {
            var existingTaskDetail = await _unitOfWork.Task.Get(id);
            if (existingTaskDetail == null)
            {
                return NotFound();
            }

            _unitOfWork.Task.Update(task);
            await this._unitOfWork.SaveChangesAsync();

            return this.Ok(task);
        }
    }
}
