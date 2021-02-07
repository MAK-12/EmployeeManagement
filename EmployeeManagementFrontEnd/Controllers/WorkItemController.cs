using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagementPortal.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EmployeeManagementPortal.MVC.Services;
using System.Threading.Tasks;
using EmployeeManagement.Infra.Models;

namespace EmployeeManagementPortal.MVC.Controllers
{
    public class WorkItemController : Controller
    {
        IList<WorkItemViewModel> taskTestDataRepository = GetTestData.GetTaskData();
        private IWorkItemService workItemService;
        public WorkItemController(IWorkItemService workItemService)
        {
            this.workItemService = workItemService;
        }

        #region GET
        // GET: TaskController
        public async Task<IActionResult> Index()
        {
            var workItem = await this.workItemService.GetWorkItems();

            var workItems = workItem.Select(w => new WorkItemViewModel()
            {
                TaskId = w.TaskId,
                Name = w.Name,
                NoOfHours = w.NoOfHours,
                IsCompleted = w.IsCompleted,
            });
            //IList<TaskViewModel> test = GetTestData.GetTaskData();
            //foreach (var item in test)
            //{
            //    item.IsCompleted = item.IsCompleted == true ? "Completed" : "Not Completed";
            //}
            return View(workItems);
        }

        private static WorkItemViewModel MapObjectsDTOtoViewModel(WorkItem dto)
        {
            return new WorkItemViewModel()
            {
                TaskId = dto.TaskId,
                Name = dto.Name,
                NoOfHours = dto.NoOfHours,
                IsCompleted = dto.IsCompleted,
            };
        }
        private static WorkItem MapObjectsViewModeltoDTO(WorkItemViewModel workItemViewModel)
        {
            return new WorkItem()
            {
                TaskId = workItemViewModel.TaskId,
                Name = workItemViewModel.Name,
                NoOfHours = workItemViewModel.NoOfHours,
                IsCompleted = workItemViewModel.IsCompleted,
            };
        }


        // GET: TaskController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // GET: TaskController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var dto = await this.workItemService.GetWorkItemById(id);
            WorkItemViewModel workItemViewModel = MapObjectsDTOtoViewModel(dto);
            return View(workItemViewModel);
        }

        // GET: TaskController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var dto = await this.workItemService.GetWorkItemById(id);
            WorkItemViewModel workItemViewModel = MapObjectsDTOtoViewModel(dto);
            return View(workItemViewModel);
        }

        // GET: TaskController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var isDeleted = await this.workItemService.DeleteWorkItem(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region POST 
        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(WorkItemViewModel workItemViewModel)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                try
                {
                    var emp = await this.workItemService.CreateWorkItem(MapObjectsViewModeltoDTO(workItemViewModel));
                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    return View(ex.InnerException.Message);
                }
            }

            return View();
        }

        // POST: TaskController/Edit/5
        public async Task<ActionResult> EditAsync(WorkItemViewModel workItemViewModel)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                var emp = await this.workItemService.UpdateWorkItem(MapObjectsViewModeltoDTO(workItemViewModel));
                return RedirectToAction("Index");
            }
            return View(workItemViewModel);
        }

        #endregion
    }
}