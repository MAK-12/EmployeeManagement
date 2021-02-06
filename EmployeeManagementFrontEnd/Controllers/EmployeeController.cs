using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementPortal.MVC.Services;
using EmployeeManagementPortal.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        IList<EmployeeViewModel> employeeRepository = GetTestData.GetEmployeeData();
        private IEmployeeManagementService employeeMGMTService;

        public EmployeeController(IEmployeeManagementService employeeMGMTService)
        {
            this.employeeMGMTService = employeeMGMTService;
        }
        
        #region Get
        //Default action...
        public async Task<IActionResult> IndexAsync()
        {
            var emp = await this.employeeMGMTService.GetEmployees();
            return View(emp);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // GET: Employee/Details/5
        [HttpGet]
        public ActionResult Details(int employeeId)
        {
            var selectedEmployee = employeeRepository.FirstOrDefault(x => x.EmployeeId == employeeId);
            return View(selectedEmployee);
        }
        
       
        // GET: Employee/Edit/5
        public ActionResult Edit(int employeeId)
        {
            //here, get the employee from the database
            var selectedEmployee = employeeRepository.Where(s => s.EmployeeId == employeeId).FirstOrDefault();

            return View(selectedEmployee);
        }
         
        #endregion

        #region POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel employeeViewModel)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                try
                {
                    employeeRepository.Add(employeeViewModel);
                    return RedirectToAction(nameof(IndexAsync));
                }

                catch (Exception ex)
                {
                    return View(ex.InnerException.Message);
                }
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                var selectedEmployee = employeeRepository.Where(s => s.EmployeeId == employeeViewModel.EmployeeId).FirstOrDefault();
                employeeRepository.Remove(selectedEmployee);
                employeeRepository.Add(employeeViewModel);

                return RedirectToAction("Index");
            }
            return View(employeeViewModel);
        }

        // GET: Employee/Delete/5
        [HttpGet]
        public ActionResult Delete(int employeeId)
        { 
            try
            {
                // TODO: Add delete logic here
                var employeeToRemove = employeeRepository.FirstOrDefault(x => x.EmployeeId == employeeId);
                if (employeeToRemove != null)
                {
                    employeeRepository.Remove(employeeToRemove);
                }
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
         
        public ActionResult Search(string searchTerm)
        {
            var result = employeeRepository.Where(a => a.FirstName.Contains(searchTerm)).ToList();
            return View("index", result);
        }

        #endregion

        #region TESTDelLater
        [HttpPost]
        //Replace IActionResult with JsonResult
        public IActionResult SaveEmployee(string employeeJson)
        {
            //Validate Models
            //if (!ModelState.IsValid)
            //{

            //}

            //Call Web API Send Data


            //if (!ModelState.IsValid)
            //{
            //    return Json(new { Success = false, NullParameter = "Parameter is null" }, JsonRequestBehavior.AllowGet);
            //}

            //var js = new JavaScriptSerializer();
            //CreateUpdateCouncillorViewModel[] council = js.Deserialize<CreateUpdateCouncillorViewModel[]>(councilsJson);
            //if (council != null)
            //{
            //    var error = ValidateData(council[0]);
            //    if (error != string.Empty)
            //        return Json(new { Success = false, Error = error }, JsonRequestBehavior.AllowGet);

            //    CouncillorEntity entity = new CouncillorEntity();
            //    var id = AssignValues(entity, council[0]);
            //    return Json(new { Success = true, Id = id }, JsonRequestBehavior.AllowGet);
            //}
            return View();
        }

        //    // GET: Employee/Delete/5
        //    public ActionResult Delete(int id)
        //    {
        //        var employee = employeeRepository.FindByID(id);
        //        return View(employee);
        //    }

        //    // POST: Employee/Delete/5
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Delete(int id, Employee e)
        //    {
        //        try
        //        {
        //            // TODO: Add delete logic here
        //            employeeRepository.Delete(id);
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }

        //    public ActionResult Search(string term)
        //    {
        //        var result = employeeRepository.Search(term);
        //        return View("index", result);
        //    }
        //}

        // GET: Employee/Delete/5
        public ActionResult DeleteOld1(int employeeId)
        {
            var selectedEmployee = employeeRepository.FirstOrDefault(x => x.EmployeeId == employeeId);
            return View(selectedEmployee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOld(int employeeId, EmployeeViewModel employeeViewModel)
        {
            try
            {
                // TODO: Add delete logic here
                var employeeToRemove = employeeRepository.FirstOrDefault(x => x.EmployeeId == employeeId);
                if (employeeToRemove != null)
                {
                    employeeRepository.Remove(employeeToRemove);
                }
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }


        #endregion
    }
}