using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementPortal.MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementPortal.MVC.Controllers
{
    public class EmployeeTaskController : Controller
    {
        IList<EmployeeTasksViewModel> employeeTaskRepository = GetTestData.GetEmployeeTaskData();

        #region Get
        //GET: EmployeeTaskController
        public ActionResult Index()
        {
            return View(employeeTaskRepository);
        }

        // GET: EmployeeTaskController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var selectedEmployee = employeeTaskRepository.FirstOrDefault(x => x.EmployeeTaskId == id);
            return View(selectedEmployee);
        }

        // GET: EmployeeTaskController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: EmployeeTaskController/Edit/5
        public ActionResult Edit(int id)
        {
            //here, get the employee from the database
            var selectedEmployee = employeeTaskRepository.Where(s => s.EmployeeTaskId == id).FirstOrDefault();

            return View(selectedEmployee);
        }

       
        #endregion

        #region Post
        // POST: EmployeeTaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        public ActionResult Create(EmployeeTasksViewModel EmployeeTasksViewModel)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                try
                {
                    employeeTaskRepository.Add(EmployeeTasksViewModel);
                    return RedirectToAction(nameof(Index));
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
        // public ActionResult Edit(int id, IFormCollection collection)
        public ActionResult Edit(EmployeeTasksViewModel employeeTasksViewModel)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                var selectedEmployee = employeeTaskRepository.Where(s => s.EmployeeTaskId == employeeTasksViewModel.EmployeeTaskId).FirstOrDefault();
                employeeTaskRepository.Remove(selectedEmployee);
                employeeTaskRepository.Add(employeeTasksViewModel);

                return RedirectToAction("Index");
            }
            return View(employeeTasksViewModel);
        }

        // POST: EmployeeTaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        // public ActionResult Delete(int id, IFormCollection collection)
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var employeeToRemove = employeeTaskRepository.FirstOrDefault(x => x.EmployeeTaskId == id);
                if (employeeToRemove != null)
                {
                    employeeTaskRepository.Remove(employeeToRemove);
                }
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
