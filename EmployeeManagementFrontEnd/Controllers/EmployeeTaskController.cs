using System;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementPortal.MVC.Common;
using EmployeeManagementPortal.MVC.Entities;
using EmployeeManagementPortal.MVC.Services;
using EmployeeManagementPortal.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementPortal.MVC.Controllers
{
    public class EmployeeTaskController : Controller
    {
        private IEmployeeTaskService employeeTaskService;
        private IEmployeeService employeeService;
        private IWorkItemService workItemService;
        private IRolesService rolesService;
        private IObjectMapper _objectMapper;

        public EmployeeTaskController(IEmployeeTaskService employeeTaskService, IEmployeeService employeeService, IWorkItemService workItemService, IRolesService rolesService, IObjectMapper objectMapper)
        {
            this.employeeTaskService = employeeTaskService;
            this.employeeService = employeeService;
            this.workItemService = workItemService;
            this.rolesService = rolesService;
            _objectMapper = objectMapper;
        }

        //GET: EmployeeTaskController
        public async Task<IActionResult> Index()
        {
            var employeeTasksList = await this.employeeTaskService.GetEmployeeTasks();
            var employeeList = await this.employeeService.GetEmployees();
            var workItemList = await this.workItemService.GetWorkItems();

            var employeeTask = employeeTasksList.Select(e => new EmployeeTasksViewModel()
            {
                EmployeeTaskId = e.EmployeeTaskId,
                TaskId = e.TaskId,
                EmployeeName = employeeList.Where(x => x.EmployeeId == e.EmployeeId).Select(x => x.FirstName + " " + x.Surname).FirstOrDefault().ToString(),
                TaskName = workItemList.Where(x => x.TaskId == e.TaskId).Select(x => x.Name).FirstOrDefault().ToString(),
                EmployeeId = e.EmployeeId,
                TotalNoOfHours = e.TotalNoOfHours,
                CurrentDate = e.CurrentDate,
                Priority = e.Priority,
                PayPerTask = e.PayPerTask
            });
            return View(employeeTask);
        }

        private static EmployeeTasksViewModel MapObjectsDTOtoViewModel(EmployeeTask dto)
        {
            return new EmployeeTasksViewModel()
            {
                EmployeeTaskId = dto.EmployeeTaskId,
                TaskId = dto.TaskId,
                EmployeeId = dto.EmployeeId,
                TotalNoOfHours = dto.TotalNoOfHours,
                CurrentDate = dto.CurrentDate,
                Priority = dto.Priority,
                PayPerTask = dto.PayPerTask
            };
        }
        private static EmployeeTask MapObjectsViewModeltoDTO(EmployeeTasksViewModel employeeTasksViewModel)
        {
            return new EmployeeTask()
            {
                EmployeeTaskId = employeeTasksViewModel.EmployeeTaskId,
                TaskId = employeeTasksViewModel.TaskId,
                EmployeeId = employeeTasksViewModel.EmployeeId,
                TotalNoOfHours = employeeTasksViewModel.TotalNoOfHours,
                CurrentDate = employeeTasksViewModel.CurrentDate,
                Priority = employeeTasksViewModel.Priority,
                PayPerTask = employeeTasksViewModel.PayPerTask
            };
        }


        // GET: EmployeeTaskController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var dto = await this.employeeTaskService.GetEmployeeTaskById(id);
            EmployeeTasksViewModel employeeTasksViewModel = MapObjectsDTOtoViewModel(dto);
            return View(employeeTasksViewModel);
        }


        //https://localhost:44396/Home/ViewPayslip/1123
        // GET: Employee/Edit/5
        //[Route("~/ViewPayslip/{accessCode}")]
        public async Task<ActionResult> GetEmployeeSalary(string accessCode)
        {
            EmployeeSalaryViewModel evm = new EmployeeSalaryViewModel();
            evm.TotalNoOfHoursWorked = 0;
            evm.Salary = 0;
            DateTime monthStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var todaysDateandTime = DateTime.Now;
            var currentDate = todaysDateandTime.Date;

            // var dto = await this.employeeTaskService.GetEmpHourCapacityOfTheDate(id);
            // EmployeeViewModel employeeViewModel = _objectMapper.EmployeeToEmployeeViewModel(dto);
            //return View(employeeViewModel);


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

        // GET: EmployeeTaskController/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var employeesAndworkItems = await this.employeeTaskService.GetEmployeesAndWorkItems("test");
            EmployeeTasksViewModel employeeTasksViewModel = _objectMapper.MapemployeesAndworkItemstoViewModel(employeesAndworkItems);
            return View(employeeTasksViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var dto = await this.employeeTaskService.GetEmployeeTaskById(id);
            EmployeeTasksViewModel employeeTasksViewModel = MapObjectsDTOtoViewModel(dto);
            return View(employeeTasksViewModel);
        }

        // POST: EmployeeTaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        public async Task<ActionResult> CreateAsync(EmployeeTasksViewModel employeeTasksViewModel)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                try
                {
                    var dtemployeeList = await this.employeeService.GetEmployeeById(employeeTasksViewModel.EmployeeId);
                    var dtRoleList = await this.rolesService.GetRoleById(dtemployeeList.RoleId);
                    employeeTasksViewModel.CurrentDate = DateTime.Now;
                    employeeTasksViewModel.PayPerTask = dtRoleList.RatePerhour;

                    var emp = await this.employeeTaskService.CreateEmployeeTask(MapObjectsViewModeltoDTO(employeeTasksViewModel));
                    return RedirectToAction("Index");
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
        public async Task<ActionResult> Edit(EmployeeTasksViewModel employeeTasksViewModel)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                var emp = await this.employeeTaskService.UpdateEmployeeTask(MapObjectsViewModeltoDTO(employeeTasksViewModel));
                return RedirectToAction("Index");
            }
            return View(employeeTasksViewModel);
        } 

        // Get: EmployeeTaskController/Delete/5 
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var isDeleted = await this.employeeTaskService.DeleteEmployeeTask(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
