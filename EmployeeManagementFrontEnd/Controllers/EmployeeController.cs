using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Infra.Models;
using EmployeeManagementPortal.MVC.Common;
using EmployeeManagementPortal.MVC.Services;
using EmployeeManagementPortal.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        private IObjectMapper _objectMapper;
        

        public EmployeeController(IEmployeeService employeeService, IObjectMapper objectMapper)
        {
            _employeeService = employeeService;
           _objectMapper = objectMapper;
        }

        //Default action...
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetEmployees();
            //dto

            var employee = employees.Select(e => new EmployeeViewModel()
            {
                EmployeeId = e.EmployeeId,
                FullName = e.FirstName + " " + e.Surname,
                MobileNo = e.MobileNo,
                EmployeeRoleName = e.Role.RoleName,
            });
            return View(employee);
        }

        // GET: EmployeeController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // GET: Employee/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int employeeId)
        {
            var dto = await _employeeService.GetEmployeeById(employeeId);
            EmployeeViewModel employeeViewModel = _objectMapper.EmployeeToEmployeeViewModel(dto);
            return View(employeeViewModel);
        }
       
       

        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int employeeId)
        {
            var dto = await _employeeService.GetEmployeeById(employeeId);
            EmployeeViewModel employeeViewModel = _objectMapper.EmployeeToEmployeeViewModel(dto);
            return View(employeeViewModel);
        }

      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(EmployeeViewModel employeeViewModel)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                try
                {
                    var emp = await _employeeService.CreateEmployee(_objectMapper.EmployeeViewModelToEmployee(employeeViewModel));
                    return RedirectToAction("Index");
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
        public async Task<ActionResult> EditAsync(EmployeeViewModel employeeViewModel)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                var emp = await _employeeService.UpdateEmployee(_objectMapper.EmployeeViewModelToEmployee(employeeViewModel));
                return RedirectToAction("Index");
            }
            return View(employeeViewModel);
        }

        // GET: Employee/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int employeeId)
        {
            try
            {
                var isDeleted = await _employeeService.DeleteEmployee(employeeId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Search(string searchTerm)
        {
            IEnumerable<EmployeeViewModel> erer = (IEnumerable<EmployeeViewModel>)await _employeeService.GetEmployees();
            var selectedEmployee = erer.Where(s => s.FirstName == searchTerm).FirstOrDefault();

            //var result = emp.Where(a => a.FirstName.Contains(searchTerm)).ToList();
            //return View("index", result);
            return View(selectedEmployee);
        }

      

        [HttpGet]
        public IActionResult GetEmployeeSalary()
        {
            return View();
        }


        //https://localhost:44396/Home/ViewPayslip/1123
        // GET: Employee/Edit/5
        //[Route("~/ViewPayslip/{accessCode}")]
        public async Task<ActionResult> GetEmployeeSalary(string accessCode)
        {
            //IList<EmployeeTasksViewModel> employeeTaskTestDataRepository = GetTestData.GetEmployeeTaskData();
            EmployeeSalaryViewModel evm = new EmployeeSalaryViewModel();
            evm.TotalNoOfHoursWorked = 0;
            evm.Salary = 0;
            DateTime monthStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var todaysDateandTime = DateTime.Now;
            var currentDate = todaysDateandTime.Date;

            ////for testing hardcoding the Access code as ACC123Jhon refers to employee id 1 and emp name will be FNameJohn
            //var selectedEmployee = employeeTestDataRepository.Where(s => s.AccessCode == "ACC123Jhon").FirstOrDefault();
            //evm.EmployeeId = selectedEmployee.EmployeeId;
            //evm.FullName = selectedEmployee.FirstName + " " + selectedEmployee.Surname;

            //var empSalaryData = employeeTaskTestDataRepository.Where(s => s.EmployeeId == selectedEmployee.EmployeeId
            //                                        && s.CurrentDate >= monthStartDate && s.CurrentDate <= currentDate).ToList();

            ////evm.StartDate = empSalaryData.Select(x => x.StartDate).FirstOrDefault();
            ////evm.EndDate = empSalaryData.Select(x => x.EndDate).FirstOrDefault();

            //evm.StartDate = monthStartDate;
            //evm.EndDate = currentDate;

            ////Calculating the Employee Salary
            //foreach (var item in empSalaryData)
            //{
            //    evm.TotalNoOfHoursWorked += item.TotalNoOfHours;
            //    evm.Salary = (decimal)(evm.Salary + (item.TotalNoOfHours * item.PayPerTask));
            //}
            return View(evm);
        }

        #region OptionsToLookat
        //     if (result.IsLockedOut)
    //            {
    //                return View("AccountLocked");
    //}
    //ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

        // ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                //return View("NotFound");
        #endregion 
       
    }
}