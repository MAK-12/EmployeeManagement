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
        IList<EmployeeViewModel> employeeTestDataRepository = GetTestData.GetEmployeeData();

        private IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        #region Get
        //Default action...
        public async Task<IActionResult> IndexAsync()
        {
            var employees = await this.employeeService.GetEmployees();

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
            var dto = await this.employeeService.GetEmployeeById(employeeId);
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
                PhysicalAddress = dto.PhysicalAddress,
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
                RoleId = 1,
            };
        }

        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int employeeId)
        {
            var dto = await this.employeeService.GetEmployeeById(employeeId);
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
                    var emp = await this.employeeService.CreateEmployee(MapObjectsViewModeltoDTO(employeeViewModel));
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
                var emp = await this.employeeService.UpdateEmployee(MapObjectsViewModeltoDTO(employeeViewModel));
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
                var isDeleted = await this.employeeService.DeleteEmployee(employeeId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Search(string searchTerm)
        {
            IEnumerable<EmployeeViewModel> erer = (IEnumerable<EmployeeViewModel>)await employeeService.GetEmployees();
            var selectedEmployee = erer.Where(s => s.FirstName == searchTerm).FirstOrDefault();

            //var result = emp.Where(a => a.FirstName.Contains(searchTerm)).ToList();
            //return View("index", result);
            return View(selectedEmployee);
        }

        #endregion

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
            IList<EmployeeTasksViewModel> employeeTaskTestDataRepository = GetTestData.GetEmployeeTaskData();
            EmployeeSalaryViewModel evm = new EmployeeSalaryViewModel();
            evm.TotalNoOfHoursWorked = 0;
            evm.Salary = 0;
            DateTime monthStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var todaysDateandTime = DateTime.Now;
            var currentDate = todaysDateandTime.Date;

            //for testing hardcoding the Access code as ACC123Jhon refers to employee id 1 and emp name will be FNameJohn
            var selectedEmployee = employeeTestDataRepository.Where(s => s.AccessCode == "ACC123Jhon").FirstOrDefault();
            evm.EmployeeId = selectedEmployee.EmployeeId;
            evm.FullName = selectedEmployee.FirstName + " " + selectedEmployee.Surname;

            var empSalaryData = employeeTaskTestDataRepository.Where(s => s.EmployeeId == selectedEmployee.EmployeeId
                                                    && s.CurrentDate >= monthStartDate && s.CurrentDate <= currentDate).ToList();

            //evm.StartDate = empSalaryData.Select(x => x.StartDate).FirstOrDefault();
            //evm.EndDate = empSalaryData.Select(x => x.EndDate).FirstOrDefault();

            evm.StartDate = monthStartDate;
            evm.EndDate = currentDate;

            //Calculating the Employee Salary
            foreach (var item in empSalaryData)
            {
                evm.TotalNoOfHoursWorked += item.TotalNoOfHours;
                evm.Salary = (decimal)(evm.Salary + (item.TotalNoOfHours * item.PayPerTask));
            }
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