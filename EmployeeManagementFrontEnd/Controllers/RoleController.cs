using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementPortal.MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementPortal.MVC.Controllers
{
    public class RoleController : Controller
    {
        IList<RoleViewModel> roleRepository = GetTestData.GetRoleData();

        #region Get
        // GET: RoleController
        public ActionResult Index()
        {
            return View(roleRepository);
        }

        // GET: RoleController/Details/5
        public ActionResult Details(int id)
        {
            var selectedEmployee = roleRepository.FirstOrDefault(x => x.RoleId == id);
            return View(selectedEmployee);
        }

        // GET: RoleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: RoleController/Edit/5
        public ActionResult Edit(int id)
        {
            var selectedEmployee = roleRepository.Where(s => s.RoleId == id).FirstOrDefault();

            return View(selectedEmployee);
        }

        // GET: RoleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        #endregion

        #region Post 
        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoleViewModel RoleViewModel)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                try
                {
                    roleRepository.Add(RoleViewModel);
                    return RedirectToAction(nameof(Index));
                }

                catch (Exception ex)
                {
                    return View(ex.InnerException.Message);
                }
            }

            return View();
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoleViewModel RoleViewModel)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                var selectedEmployee = roleRepository.Where(s => s.RoleId == RoleViewModel.RoleId).FirstOrDefault();
                roleRepository.Remove(selectedEmployee);
                roleRepository.Add(RoleViewModel);

                return RedirectToAction("Index");
            }
            return View(RoleViewModel);
        }

        // POST: RoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var employeeToRemove = roleRepository.FirstOrDefault(x => x.RoleId == id);
                if (employeeToRemove != null)
                {
                    roleRepository.Remove(employeeToRemove);
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
