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

            var employees = emp.Select(e => new EmployeeViewModel()
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                Surname = e.Surname,
                EmployeeRoleName = e.Role.RoleName,
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
            var dto = await this.employeeMGMTService.GetEmployeeById(employeeId);
            EmployeeViewModel employeeViewModel = MapObjectsDTOtoViewModel(dto);
            return View(employeeViewModel);
        }

        private static EmployeeViewModel MapObjectsDTOtoViewModel(Employee dto)
        {
            return new EmployeeViewModel()
            {
                FirstName = dto.FirstName,
                AccessCode = dto.AccessCode,
                EmailAddress = dto.EmailAddress,
                EmployeeCode = dto.EmployeeCode,
                EmployeeId = dto.EmployeeId,
                MobileNo = dto.MobileNo,
                Surname = dto.Surname,
                MiddleName = dto.MiddleName,
                PhysicalAddress = dto.PhysicalAddress
            };
        }
        private static Employee MapObjectsViewModeltoDTO(EmployeeViewModel employeeViewModel)
        {
            return new Employee()
            {
                FirstName = employeeViewModel.FirstName,
                AccessCode = employeeViewModel.AccessCode,
                EmailAddress = employeeViewModel.EmailAddress,
                EmployeeCode = employeeViewModel.EmployeeCode,
                EmployeeId = employeeViewModel.EmployeeId,
                MobileNo = employeeViewModel.MobileNo,
                Surname = employeeViewModel.Surname,
                MiddleName = employeeViewModel.MiddleName,
                PhysicalAddress = employeeViewModel.PhysicalAddress,
            };
        }

        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int employeeId)
        {
            var dto = await this.employeeMGMTService.GetEmployeeById(employeeId);
            EmployeeViewModel employeeViewModel = MapObjectsDTOtoViewModel(dto);
            return View(employeeViewModel);
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
                    var emp = await this.employeeMGMTService.CreateEmployee(MapObjectsViewModeltoDTO(employeeViewModel));
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
                var emp = await this.employeeMGMTService.UpdateEmployee(MapObjectsViewModeltoDTO(employeeViewModel));
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
                var isDeleted = await this.employeeMGMTService.DeleteEmployee(employeeId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Search(string searchTerm)
        {
            IEnumerable<EmployeeViewModel> erer = (IEnumerable<EmployeeViewModel>)await employeeMGMTService.GetEmployees();
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

            //var selectedEmployee = erer.Where(s => s.AccessCode == accessCode).FirstOrDefault();

            //List<EmployeeViewModel> dsds = 

            //here, get the employee from the database
            //var selectedEmployee = employeeRepository.Where(s => s.AccessCode == accessCode).FirstOrDefault();
            //selectedEmployee
            
            return View();
        }

        #region DeleteLater
        private Employee AssignValues(Employee employeeDTO, EmployeeViewModel employeeViewModel)
        {
            employeeDTO.FirstName = employeeViewModel.FirstName;
            employeeDTO.AccessCode = employeeViewModel.AccessCode;
            employeeDTO.EmailAddress = employeeViewModel.EmailAddress;
            employeeDTO.EmployeeCode = employeeViewModel.EmployeeCode;
            employeeDTO.EmployeeId = employeeViewModel.EmployeeId;
            employeeDTO.MobileNo = employeeViewModel.MobileNo;
            employeeDTO.Surname = employeeViewModel.Surname;
            employeeDTO.MiddleName = employeeViewModel.MiddleName;
            employeeDTO.PhysicalAddress = employeeViewModel.PhysicalAddress;
            return employeeDTO;
        }
        private EmployeeViewModel AssignValues(EmployeeViewModel employeeViewModel, Employee employeeDTO)
        {
            employeeViewModel.FirstName = employeeDTO.FirstName;
            employeeViewModel.AccessCode = employeeDTO.AccessCode;
            employeeViewModel.EmailAddress = employeeDTO.EmailAddress;
            employeeViewModel.EmployeeCode = employeeDTO.EmployeeCode;
            employeeViewModel.EmployeeId = employeeDTO.EmployeeId;
            employeeViewModel.MobileNo = employeeDTO.MobileNo;
            employeeViewModel.Surname = employeeDTO.Surname;
            employeeViewModel.MiddleName = employeeDTO.MiddleName;
            employeeViewModel.PhysicalAddress = employeeDTO.PhysicalAddress;

            return employeeViewModel;
        }
        #endregion

    }
}