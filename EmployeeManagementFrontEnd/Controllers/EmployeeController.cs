using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EmployeeManagementPortal.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.MVC.Controllers
{
    public class EmployeeController : Controller
    {

        GetTestData empVMTestData = new GetTestData();

        //Default action...
        public IActionResult Index()
        {
            var employees = empVMTestData.GetEmployeeData();

            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        public ActionResult Edit(int Id)
        {
            //here, get the student from the database in the real application

            //getting a student from collection for demo purpose
            var std = empVMTestData.GetEmployeeData().Where(s => s.EmployeeId == Id).FirstOrDefault();

            return View(std);
        }

        public ActionResult Details(int id)
        {
            var employee = empVMTestData.GetEmployeeData().SingleOrDefault(x => x.EmployeeId == id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeViewModel emp)
        {
            if (ModelState.IsValid)
            { //checking model state


                //update student in DB using EntityFramework in real-life application

                //update list by removing old student and adding updated student for demo purpose
                var student = empVMTestData.GetEmployeeData().Where(s => s.EmployeeId == emp.EmployeeId).FirstOrDefault();
                empVMTestData.GetEmployeeData().Remove(student);
                empVMTestData.GetEmployeeData().Add(emp);

                return RedirectToAction("Index");
            }

            return View(emp);

        }


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

}
}
