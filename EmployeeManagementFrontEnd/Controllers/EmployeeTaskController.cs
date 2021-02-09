﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementPortal.MVC.Common;
using EmployeeManagementPortal.MVC.Entities;
using EmployeeManagementPortal.MVC.Services;
using EmployeeManagementPortal.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementPortal.MVC.Controllers
{
    /// <summary>
    /// Assign Casual Employees to one or more Tasks and A Task can have multiple Employees assigned
    /// </summary>
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

        public async Task<IActionResult> Index()
        {
            IEnumerable<EmployeeTasksViewModel> employeeTask = await GetEmployeeTasksDataToViewModel();

            return View(employeeTask);
        }

        // GET: EmployeeTaskController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            EmployeeTasksViewModel employeeTasksViewModel = await GetEmployeeTaskDataToViewModel(id);

            return View(employeeTasksViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            EmployeeTasksViewModel employeeTasksViewModel = await GetEmployeeTaskDataToViewModel(id);
            await LoadEmployeesAndTasks(employeeTasksViewModel);

            return View(employeeTasksViewModel);
        }

        // GET: EmployeeTaskController/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            EmployeeTasksViewModel employeeTasksViewModel = new EmployeeTasksViewModel();
            await LoadEmployeesAndTasks(employeeTasksViewModel);

            return View(employeeTasksViewModel);
        }

        // POST: EmployeeTaskController/Create
        [HttpPost]
        public async Task<ActionResult> CreateAsync(EmployeeTasksViewModel employeeTasksViewModel)
        {
            bool isEmployeeHaveCapacity = true;
            isEmployeeHaveCapacity = await IsEmployeeAvailable(employeeTasksViewModel, isEmployeeHaveCapacity);

            //checking model state
            if (ModelState.IsValid)
            {
                if (isEmployeeHaveCapacity)
                {
                    try
                    {
                        await GetCurrentRatePerHour(employeeTasksViewModel);

                        var emp = await this.employeeTaskService.CreateEmployeeTask(_objectMapper.EmployeeTasksViewModelToEmployeeTasks(employeeTasksViewModel));
                        return RedirectToAction("Index");
                    }

                    catch (Exception ex)
                    {
                       
                    }
                }
                else
                {
                    ModelState.AddModelError("TotalNoOfHours", "Employee doesnt have capacity to Assgin this task");
                }
            }

            EmployeeTasksViewModel empTaskView = new EmployeeTasksViewModel();
            var employeeList = await this.employeeService.GetEmployees();
            var workItemList = await this.workItemService.GetWorkItems();

            empTaskView.Employees = employeeList;
            empTaskView.WorkItems = workItemList;

            return View(empTaskView);
        }

        //Business Rule: 12 Hours Validation-An employee can be assigned multiple tasks but cannot work more than 12 hours a day
        private async Task<bool> IsEmployeeAvailable(EmployeeTasksViewModel employeeTasksViewModel, bool isEmployeeHaveCapacity)
        {

            var todaysDateandTime = DateTime.Now;
            var currentDate = todaysDateandTime.Date;
            var employeeCapacity = await this.employeeTaskService.GetEmpHourCapacityOfTheDate(employeeTasksViewModel.EmployeeId, currentDate, null);
            var assginedtaskDuration = await this.workItemService.GetWorkItemById(employeeTasksViewModel.TaskId);
            int totalNoOfHoursWorked = 0;
            int empCapacity = 0;

            //Calculating the Employee Salary
            foreach (var item in employeeCapacity)
            {
                totalNoOfHoursWorked += item.TotalNoOfHours;
            }
            empCapacity = 12 - totalNoOfHoursWorked;

            if ((employeeTasksViewModel.TotalNoOfHours > empCapacity) || (assginedtaskDuration.NoOfHours > empCapacity))
            {
                isEmployeeHaveCapacity = false;
            }

            return isEmployeeHaveCapacity;
        }

        // POST: EmployeeTaskController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(EmployeeTasksViewModel employeeTasksViewModel)
        {
            //checking model state
            if (ModelState.IsValid)
            {
                var emp = await this.employeeTaskService.UpdateEmployeeTask(_objectMapper.EmployeeTasksViewModelToEmployeeTasks(employeeTasksViewModel));
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


        [HttpGet]
        public async Task<ActionResult> ViewTotalDuetoEmployee()
        {
            EmployeeSalaryViewModel employeeSalaryViewModel = new EmployeeSalaryViewModel();
            await GetAllEmployees(employeeSalaryViewModel);
            employeeSalaryViewModel.DispalyGrid = false;
            return View(employeeSalaryViewModel);
        }


        //View total due to Casual Employee over a specific timeframe.
        [HttpPost]
        public async Task<ActionResult> ViewTotalDuetoEmployee(int EmployeeId, DateTime startDate, DateTime endDate)
        {
            EmployeeSalaryViewModel evm = new EmployeeSalaryViewModel();
            evm.TotalNoOfHoursWorked = 0;
            evm.Salary = 0;

            var dtoEmpTask = await this.employeeTaskService.GetEmpHourCapacityOfTheDate(EmployeeId, startDate, endDate);

            var dtemployeeList = await this.employeeService.GetEmployeeById(dtoEmpTask.Select(x => x.EmployeeId).FirstOrDefault());
            evm.FullName = dtemployeeList.FirstName + " " + dtemployeeList.Surname;
            evm.DispalyGrid = true;

            //Calculating the Employee Salary
            foreach (var item in dtoEmpTask)
            {
                evm.TotalNoOfHoursWorked += item.TotalNoOfHours;
                evm.Salary = (decimal)(evm.Salary + (item.TotalNoOfHours * item.PayPerTask));
            }


            return View(evm);
        }


        [HttpGet]
        public async Task<ActionResult> GetEmployeeSalary()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> GetEmployeeSalary(EmployeeSalaryViewModel employeeSalaryViewModel)
        {
            EmployeeSalaryViewModel evm = new EmployeeSalaryViewModel();
            evm.TotalNoOfHoursWorked = 0;
            evm.Salary = 0;
            DateTime monthStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var todaysDateandTime = DateTime.Now;
            var currentDate = todaysDateandTime.Date;

            //Selecting Employee matches accessCode
            var dtemployeeList = await this.employeeService.GetEmployeeDetailsByaccessCode(employeeSalaryViewModel.AccessCode);

            //Getting Data from EmployeeTask(SalaryData) by passing EmployeeId and startDate
            var empSalaryData = await this.employeeTaskService.GetEmpHourCapacityOfTheDate(dtemployeeList.EmployeeId, monthStartDate, currentDate);


            evm.FullName = dtemployeeList.FirstName + " " + dtemployeeList.Surname;

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

        //Total Hours Per Employee Per Day
        [HttpGet]
        public async Task<ActionResult> ViewEmployeesTotalHoursPerDay()
        {
            //Get All Employee Tasks 
            var employeeTasksList = await this.employeeTaskService.GetEmployeeTasks();

            var employeesTotalHoursPerDayViewModel = employeeTasksList.Select(x => new EmployeesTotalHoursPerDayViewModel()
            {
                FullName = x.Employee.FirstName + " " + x.Employee.Surname,
                Date = x.CurrentDate,
                TotalHours = x.TotalNoOfHours,
            }).GroupBy(r => new { r.EmployeeId, r.Date }).OrderBy(g => g.Key.EmployeeId).ToList();


            //List<EmployeesTotalHoursPerDayViewModel> empTaskList = new List<EmployeesTotalHoursPerDayViewModel>();
            var invoiceSum = employeeTasksList.Select(x =>
              new EmployeesTotalHoursPerDayViewModel
              {
                  FullName = x.Employee.FirstName,
                  Date = x.CurrentDate,
                  TotalHours = x.TotalNoOfHours
              })
            .GroupBy(s => new { s.FullName, s.Date })
            .Select(g =>
                  new EmployeesTotalHoursPerDayViewModel
                  {
                      FullName = g.Key.FullName,
                      Date = g.Key.Date,
                      TotalHours = (int)g.Sum(x => Math.Round(Convert.ToDecimal(x.TotalHours), 2)),
                  }
            );
            return View(invoiceSum);
        }


        //Gets Data of All EmployeeTasks
        private async Task<IEnumerable<EmployeeTasksViewModel>> GetEmployeeTasksDataToViewModel()
        {
            var employeeTasksList = await this.employeeTaskService.GetEmployeeTasks();
            var employeesList = await this.employeeService.GetEmployees();
            var workItemsList = await this.workItemService.GetWorkItems();

            IEnumerable<EmployeeTasksViewModel> employeeTask = _objectMapper.EmployeeTasksDTOObjectsToViewModel(employeeTasksList, employeesList, workItemsList);
            return employeeTask;
        }

        //Gets Data for Specific Employee Task
        private async Task<EmployeeTasksViewModel> GetEmployeeTaskDataToViewModel(int id)
        {
            var dto = await this.employeeTaskService.GetEmployeeTaskById(id);
            EmployeeTasksViewModel employeeTasksViewModel = _objectMapper.EmployeeTaskToEmployeeTasksViewModel(dto);
            return employeeTasksViewModel;
        }

        private async Task GetAllEmployees(EmployeeSalaryViewModel employeeSalaryViewModel)
        {
            var employeeList = await this.employeeService.GetEmployees();
            employeeSalaryViewModel.Employees = employeeList;
        }


        //Get List of All Employees and Tasks(work items) assigns to View Model object
        private async Task LoadEmployeesAndTasks(EmployeeTasksViewModel employeeTasksViewModel)
        {
            var employeeList = await this.employeeService.GetEmployees();
            var workItemList = await this.workItemService.GetWorkItems();

            employeeTasksViewModel.Employees = employeeList;
            employeeTasksViewModel.WorkItems = workItemList;
        }

        //Business Rule: "Changing the hourly rate or changing the casual employee role should not affect previously
        //captured hours" i.e reason we getting the rate perhour from the Roles table and Saving in EmployeeTask tabele
        private async Task GetCurrentRatePerHour(EmployeeTasksViewModel employeeTasksViewModel)
        {
            var dtemployeeList = await this.employeeService.GetEmployeeById(employeeTasksViewModel.EmployeeId);
            var dtRoleList = await this.rolesService.GetRoleById(dtemployeeList.RoleId);

            employeeTasksViewModel.CurrentDate = DateTime.Now;
            employeeTasksViewModel.PayPerTask = dtRoleList.RatePerhour;
        }
    }
}
