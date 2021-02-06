using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagementPortal.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagementPortal.MVC.Controllers
{
    public class WorkItemController : Controller
    {
        IList<WorkItemViewModel> taskRepository = GetTestData.GetTaskData();

        #region GET
        // GET: TaskController
        public ActionResult Index()
        {
            //IList<TaskViewModel> test = GetTestData.GetTaskData();
            //foreach (var item in test)
            //{
            //    item.IsCompleted = item.IsCompleted == true ? "Completed" : "Not Completed";
            //}

            return View(taskRepository);
        }

       
        // GET: TaskController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: TaskController/Details/5
        public ActionResult Details(int taskId)
        {
            var selectedTask = taskRepository.FirstOrDefault(x => x.TaskId == taskId);
            return View(selectedTask);
        }


        // GET: TaskController/Edit/5
        public ActionResult Edit(int taskId)
        {
            //here, get the Task from the database
            var selectedTask = taskRepository.Where(s => s.TaskId == taskId).FirstOrDefault();

            return View(selectedTask);
        }

        // GET: TaskController/Delete/5
        public ActionResult Delete(int taskId)
        {
            try
            {
                // TODO: Add delete logic here
                var taskToRemove = taskRepository.FirstOrDefault(x => x.TaskId == taskId);
                if (taskToRemove != null)
                {
                    taskRepository.Remove(taskToRemove);
                }
                return RedirectToAction(nameof(Index));
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
         
        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int taskId, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int taskId, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        #endregion
    }
}