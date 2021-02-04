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
          var data =  empVMTestData.GetEmployeeData();

            return View();
        }

        public IActionResult Create()
        {
           return View();
        }

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }

        // GET: Movies/Details/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empData = empVMTestData.GetEmployeeData();
            if (empData == null)
            {
                return NotFound();
            }

            return View(empData);
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

    }
}
