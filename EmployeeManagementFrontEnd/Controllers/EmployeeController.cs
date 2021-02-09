using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementPortal.MVC.Common;
using EmployeeManagementPortal.MVC.Services;
using EmployeeManagementPortal.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace EmployeeManagement.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        private IObjectMapper _objectMapper;
        private readonly ILogger _logger;

        public EmployeeController(IEmployeeService employeeService, IObjectMapper objectMapper, ILogger<EmployeeController> logger)
        {
           _employeeService = employeeService;
           _objectMapper = objectMapper;
           _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("GetAllEmployees");
            var employees = await _employeeService.GetEmployees();
            //dto

            var employee = employees.Select(e => new EmployeeViewModel()
            {
                EmployeeId = e.EmployeeId,
                FullName = e.FirstName + " " + e.Surname,
                MobileNo = e.MobileNo,
                EmailAddress = e.EmailAddress,
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
        public async Task<ActionResult> Details(int id)
        {
            _logger.LogInformation("GetEmployeeById");
            var dto = await _employeeService.GetEmployeeById(id);
            EmployeeViewModel employeeViewModel = _objectMapper.EmployeeToEmployeeViewModel(dto);
            return View(employeeViewModel);
        }
       
       

        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            _logger.LogInformation("Update");
            var dto = await _employeeService.GetEmployeeById(id);
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
                    _logger.LogError("Error Creating Employee {0}",ex.Message);
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
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var isDeleted = await _employeeService.DeleteEmployee(id);
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
    }
}