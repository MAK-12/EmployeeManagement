using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Infra.Models;
using EmployeeManagementPortal.MVC.Services;
using EmployeeManagementPortal.MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagementPortal.MVC.Controllers
{
    public class EmployeeTaskController : Controller
    {
        private IEmployeeTaskService employeeTaskService;
        private IEmployeeService employeeService;
        private IWorkItemService workItemService;
        private IRolesService rolesService;

        public EmployeeTaskController(IEmployeeTaskService employeeTaskService, IEmployeeService employeeService, IWorkItemService workItemService, IRolesService rolesService)
        {
            this.employeeTaskService = employeeTaskService;
            this.employeeService = employeeService;
            this.workItemService = workItemService;
            this.rolesService = rolesService; 
        }

        #region Get
        //GET: EmployeeTaskController
        public async Task<IActionResult> Index()
        {
            var employeeTasksList = await this.employeeTaskService.GetEmployeeTasks();
            var employeeList = await this.employeeService.GetEmployees();
            var workItemList = await this.workItemService.GetWorkItems(); 

            var employeeTask = employeeTasksList.Select(e => new EmployeeTasksViewModel()
            {
                EmployeeTaskId = e.EmployeeTaskId,
                TaskId = e.TaskId,
                EmployeeName = employeeList.Where(x => x.EmployeeId == e.EmployeeId).Select(x => x.FirstName + " " + x.Surname).FirstOrDefault().ToString(),
                TaskName = workItemList.Where(x => x.TaskId == e.TaskId).Select(x =>x.Name).FirstOrDefault().ToString(),
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
        public async Task<IActionResult> Create()
        {
            var employeeList = await this.employeeService.GetEmployees();
            var workItemList = await this.workItemService.GetWorkItems();
            EmployeeTasksViewModel employeeTasksViewModel = new EmployeeTasksViewModel();

            employeeTasksViewModel.EmployeeList = employeeList;
            employeeTasksViewModel.WorkItemList = workItemList;

            return View(employeeTasksViewModel);
        }

        [HttpGet]
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
                    var dtemployeeList = await this.employeeService.GetEmployeeById(employeeTasksViewModel.EmployeeId);
                    var dtRoleList = await this.rolesService.GetRoleById(dtemployeeList.RoleId);
                    employeeTasksViewModel.CurrentDate = DateTime.Now;
                    employeeTasksViewModel.PayPerTask = dtRoleList.RatePerhour;

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
