using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Infra.Models;
using EmployeeManagementPortal.MVC.Services;
using EmployeeManagementPortal.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        //IList<EmployeeViewModel> employeeRepository = GetTestData.GetEmployeeData();
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
             
            //var employees = new List<EmployeeViewModel>();

            var employees = emp.Select(
                e => new EmployeeViewModel()
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    Surname = e.Surname,
                    EmployeeRoleName = "dsds",
                });
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // GET: Employee/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int employeeId)
        {
            var emp = await this.employeeMGMTService.GetEmployeeById(employeeId);
            EmployeeViewModel employeeViewModel = MapObjects(emp);
            return View(employeeViewModel);
        }

        private static EmployeeViewModel MapObjects(Employee emp)
        {
            return new EmployeeViewModel()
            {
                FirstName = emp.FirstName,
                AccessCode = emp.AccessCode,
                EmailAddress = emp.EmailAddress,
                EmployeeCode = emp.EmployeeCode,
                EmployeeId = emp.EmployeeId,
                MobileNo = emp.MobileNo,
                Surname = emp.Surname,
                MiddleName = emp.MiddleName,
                PhysicalAddress = emp.PhysicalAddress
            };
        }

        private Employee AssignValues(Employee employee, EmployeeViewModel employeeViewModel)
        {
            employee.FirstName = employeeViewModel.FirstName;
            employee.AccessCode = employeeViewModel.AccessCode;
            employee.EmailAddress = employeeViewModel.EmailAddress;
            employee.EmployeeCode = employeeViewModel.EmployeeCode;
            employee.EmployeeId = employeeViewModel.EmployeeId;
            employee.MobileNo = employeeViewModel.MobileNo;
            employee.Surname = employeeViewModel.Surname;
            employee.MiddleName = employeeViewModel.MiddleName;
            employee.PhysicalAddress = employeeViewModel.PhysicalAddress;
            return employee;
        }
        private EmployeeViewModel AssignValues(EmployeeViewModel employeeViewModel, Employee employee)
        {
           employeeViewModel.FirstName = employee.FirstName;
           employeeViewModel.AccessCode = employee.AccessCode;
           employeeViewModel.EmailAddress = employee.EmailAddress;
           employeeViewModel.EmployeeCode = employee.EmployeeCode;
           employeeViewModel.EmployeeId = employee.EmployeeId;
           employeeViewModel.MobileNo = employee.MobileNo;
           employeeViewModel.Surname = employee.Surname;
           employeeViewModel.MiddleName = employee.MiddleName;
           employeeViewModel.PhysicalAddress = employee.PhysicalAddress;
            
            return employeeViewModel;
        }

        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int employeeId)
        {
            //here, get the employee from the database

            var selectedEmployee = this.employeeMGMTService.GetEmployeeById(employeeId);
            //var selectedEmployee1 = employeeRepository.Where(s => s.EmployeeId == employeeId).FirstOrDefault();
            //var employees = new List<EmployeeViewModel>();
            //foreach (EmployeeViewModel employee in selectedEmployee)
            //{

            //}
            return View(selectedEmployee); 
        }
         
        #endregion

        #region POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(EmployeeViewModel employeeViewModel)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                try
                {
                    var employeeDTO = new Employee()
                    {
                        FirstName = employeeViewModel.FirstName,
                        Surname = employeeViewModel.Surname,
                        RoleId = 1,
                        MobileNo = employeeViewModel.MobileNo,
                        EmailAddress =employeeViewModel.EmailAddress,
                    };

                    var emp = await this.employeeMGMTService.CreateEmployee(employeeDTO);
                   // employeeRepository.Add(employeeViewModel);
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
                var employeeDTO = new Employee()
                {
                    FirstName = employeeViewModel.FirstName,
                    Surname = employeeViewModel.Surname,
                    RoleId = 1,
                    MobileNo = employeeViewModel.MobileNo,
                    EmailAddress = employeeViewModel.EmailAddress,
                };

                var emp = await this.employeeMGMTService.UpdateEmployee(employeeDTO);

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
                // TODO: Add delete logic here
                var isDeleted = this.employeeMGMTService.DeleteEmployee(employeeId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
         
        public async Task<ActionResult> Search(string searchTerm)
        {
            IEnumerable<EmployeeViewModel> erer = (IEnumerable<EmployeeViewModel>)employeeMGMTService.GetEmployees();
            var selectedEmployee = erer.Where(s => s.FirstName == searchTerm).FirstOrDefault();

            //var result = emp.Where(a => a.FirstName.Contains(searchTerm)).ToList();
            //return View("index", result);
            return View(selectedEmployee);
        }

        #endregion

        //https://localhost:44396/Home/ViewPayslip/1123
        // GET: Employee/Edit/5
        [Route("~/ViewPayslip/{accessCode}")]
        public async Task<ActionResult> GetEmployeeSalary(string accessCode)
        {
            IEnumerable<EmployeeViewModel> erer = (IEnumerable<EmployeeViewModel>)employeeMGMTService.GetEmployees();
            var selectedEmployee = erer.Where(s => s.AccessCode == accessCode).FirstOrDefault();

            //List<EmployeeViewModel> dsds = 

            //here, get the employee from the database
            //var selectedEmployee = employeeRepository.Where(s => s.AccessCode == accessCode).FirstOrDefault();

            return View(selectedEmployee);
        }

    }
}