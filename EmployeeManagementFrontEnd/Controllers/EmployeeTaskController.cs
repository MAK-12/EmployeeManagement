using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Infra.Models;
using EmployeeManagementPortal.MVC.Services;
using EmployeeManagementPortal.MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementPortal.MVC.Controllers
{
    public class EmployeeTaskController : Controller
    {
        private IEmployeeTaskService employeeTaskService;

        public EmployeeTaskController(IEmployeeTaskService employeeTaskService)
        {
            this.employeeTaskService = employeeTaskService;
        }

        #region Get
        //GET: EmployeeTaskController
        public async Task<IActionResult> Index()
        {
            var employeeTasks = await this.employeeTaskService.GetEmployeeTasks();

            var employeeTask = employeeTasks.Select(e => new EmployeeTasksViewModel()
            {
                EmployeeTaskId = e.EmployeeTaskId,
                TaskId = e.TaskId,
                EmployeeId = e.EmployeeId,
                TotalNoOfHours = e.TotalNoOfHours,
                CurrentDate = e.CurrentDate,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Priority = e.Priority,
                PayPerTask = e.PayPerTask
            });
            return View(employeeTask);
        }

        private static EmployeeTasksViewModel MapObjectsDTOtoViewModel(EmployeeTask dto)
        {
            return new EmployeeTasksViewModel()
            {
                EmployeeTaskId = dto.EmployeeTaskId,
                TaskId = dto.TaskId,
                EmployeeId = dto.EmployeeId,
                TotalNoOfHours = dto.TotalNoOfHours,
                CurrentDate = dto.CurrentDate,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Priority = dto.Priority,
                PayPerTask = dto.PayPerTask
            };
        }
        private static EmployeeTask MapObjectsViewModeltoDTO(EmployeeTasksViewModel employeeTasksViewModel)
        {
            return new EmployeeTask()
            {
                EmployeeTaskId = employeeTasksViewModel.EmployeeTaskId,
                TaskId = employeeTasksViewModel.TaskId,
                EmployeeId = employeeTasksViewModel.EmployeeId,
                TotalNoOfHours = employeeTasksViewModel.TotalNoOfHours,
                CurrentDate = employeeTasksViewModel.CurrentDate,
                StartDate = (DateTime)employeeTasksViewModel.StartDate,
                EndDate = (DateTime)employeeTasksViewModel.EndDate,
                Priority = employeeTasksViewModel.Priority,
                PayPerTask = employeeTasksViewModel.PayPerTask
            };
        }


        // GET: EmployeeTaskController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var dto = await this.employeeTaskService.GetEmployeeTaskById(id);
            EmployeeTasksViewModel employeeTasksViewModel = MapObjectsDTOtoViewModel(dto);
            return View(employeeTasksViewModel);
        }

        // GET: EmployeeTaskController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // GET: EmployeeTaskController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var dto = await this.employeeTaskService.GetEmployeeTaskById(id);
            EmployeeTasksViewModel employeeTasksViewModel = MapObjectsDTOtoViewModel(dto);
            return View(employeeTasksViewModel);
        }

        #endregion

        #region Post
        // POST: EmployeeTaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        public async Task<ActionResult> CreateAsync(EmployeeTasksViewModel employeeTasksViewModel)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                try
                {
                    var emp = await this.employeeTaskService.CreateEmployeeTask(MapObjectsViewModeltoDTO(employeeTasksViewModel));
                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    return View(ex.InnerException.Message);
                }
            }

            return View();
        }

        // POST: EmployeeTaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EmployeeTasksViewModel employeeTasksViewModel)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                var emp = await this.employeeTaskService.UpdateEmployeeTask(MapObjectsViewModeltoDTO(employeeTasksViewModel));
                return RedirectToAction("Index");
            }
            return View(employeeTasksViewModel);
        }


        // Get: EmployeeTaskController/Delete/5 
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var isDeleted = await this.employeeTaskService.DeleteEmployeeTask(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion
    }
}
