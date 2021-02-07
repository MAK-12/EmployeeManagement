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
    public class WorkItemController : ControllerBase
    {

        private readonly ILogger<WorkItemController> _logger;
        private IUnitOfWork _unitOfWork;

        public WorkItemController(ILogger<WorkItemController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<WorkItem>> Get()
        {
            return await _unitOfWork.TaskRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var taskDetail = await _unitOfWork.TaskRepository.Get(id);
            if (taskDetail == null)
            {
                return NotFound();
            }

            return this.Ok(taskDetail);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var taskDetail = await _unitOfWork.TaskRepository.Get(id);
            if (taskDetail == null)
            {
                return NotFound();
            }
            _unitOfWork.TaskRepository.Delete(taskDetail);
            await this._unitOfWork.SaveChangesAsync();

            return this.Ok(taskDetail);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(String searchText)
        {
            var workItems = await _unitOfWork.TaskRepository.Find(searchText);
            return this.Ok(workItems);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeManagement.Infra.Models.WorkItem task)
        {
            _unitOfWork.TaskRepository.Add(task);
            await this._unitOfWork.SaveChangesAsync();

            return  this.Ok(task);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, EmployeeManagement.Infra.Models.WorkItem task)
        {
            var existingTaskDetail = await _unitOfWork.TaskRepository.Get(id);
            if (existingTaskDetail == null)
            {
                return NotFound();
            }
            existingTaskDetail.Name = task.Name;
            existingTaskDetail.NoOfHours = task.NoOfHours;
            existingTaskDetail.IsCompleted = task.IsCompleted;

            _unitOfWork.TaskRepository.Update(existingTaskDetail);
            await this._unitOfWork.SaveChangesAsync();

            return this.Ok(task);
        }
    }
}
