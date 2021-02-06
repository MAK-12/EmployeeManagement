using EmployeeManagementPortal.MVC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.ViewModels
{
    public class GetTestData
    {
        public static IList<EmployeeViewModel> GetEmployeeData()
        {
            IList<EmployeeViewModel> empData = new List<EmployeeViewModel>()
            {
                new EmployeeViewModel() { EmployeeId = 1, FirstName = "FNameJohn", MiddleName = "MNameJohn", Surname = "SurnameJohn", MobileNo = "1111111", EmailAddress = "John@gmail.com", PhysicalAddress = "USA", AccessCode = "ACC123Jhon", EmployeeRoleCategory = EmployeeRoleCategory.CasualEmployeeLevel1 },

               new EmployeeViewModel() { EmployeeId = 2, FirstName = "FNameSteve", MiddleName = "MNameSteve", Surname = "SurnameSteve", MobileNo = "222222222", EmailAddress = "Steve@gmail.com", PhysicalAddress = "UK", AccessCode = "ACC123Steve", EmployeeRoleCategory = EmployeeRoleCategory.CasualEmployeeLevel1 },

               new EmployeeViewModel() { EmployeeId = 3, FirstName = "FNameRam", MiddleName = "MNameRam", Surname = "SurnameRam", MobileNo = "333333333", EmailAddress = "Ram@gmail.com", PhysicalAddress = "IND", AccessCode = "ACC123Ram", EmployeeRoleCategory = EmployeeRoleCategory.CasualEmployeeLevel1 },

               new EmployeeViewModel() { EmployeeId = 4, FirstName = "FNameKrish", MiddleName = "MNameKrish", Surname = "SurnameKrish", MobileNo = "4444444444", EmailAddress = "Krish@gmail.com", PhysicalAddress = "ENGL", AccessCode = "ACC123Krish", EmployeeRoleCategory = EmployeeRoleCategory.CasualEmployeeLevel2 },

               new EmployeeViewModel() { EmployeeId = 5, FirstName = "FNameHarvey", MiddleName = "MNameHarvey", Surname = "SurnameHarvey", MobileNo = "55555555", EmailAddress = "Harvey@gmail.com", PhysicalAddress = "ZIM", AccessCode = "ACC123Harvey", EmployeeRoleCategory = EmployeeRoleCategory.CasualEmployeeLevel2 }
            };

            return empData;
        }


        public static IList<WorkItemViewModel> GetTaskData()
        {
            IList<WorkItemViewModel> taskData = new List<WorkItemViewModel>()
            {
                new WorkItemViewModel() { TaskId = 1, Name = "Requirement Analysis", NoOfHours = 2, IsCompleted = true },
                new WorkItemViewModel() { TaskId = 2, Name = "Development", NoOfHours = 8, IsCompleted = false },
                new WorkItemViewModel() { TaskId = 3, Name = "Testing", NoOfHours = 2, IsCompleted = false },
                new WorkItemViewModel() { TaskId = 4, Name = "Documentation", NoOfHours = 3, IsCompleted = false},

            };
            return taskData;
        }

        public static IList<RoleViewModel> GetRoleData()
        {
            IList<RoleViewModel> roleData = new List<RoleViewModel>()
            {
                new RoleViewModel() { RoleId = 1, RoleName = "CasualEmployeeLevel1", RatePerhour = 100 },
                new RoleViewModel() { RoleId = 2, RoleName = "CasualEmployeeLevel2", RatePerhour = 200 }

            };
            return roleData;
        }


        public static IList<EmployeeTasksViewModel> GetEmployeeTaskData()
        {
            IList<EmployeeTasksViewModel> employeeTaskData = new List<EmployeeTasksViewModel>()
            {
                new EmployeeTasksViewModel() { EmployeeTaskId = 1, EmployeeId = 1, TaskId = 1, TotalNoOfHours = 1, Priority = "High",
                                                CurrentDate = DateTime.Now, StartDate  = DateTime.Now, EndDate = DateTime.Now,
                                                PayPerTask = 100 },
                new EmployeeTasksViewModel() { EmployeeTaskId = 2, EmployeeId = 1, TaskId = 2, TotalNoOfHours = 2, Priority = "Medium",
                                                CurrentDate = DateTime.Now, StartDate  = DateTime.Now, EndDate = DateTime.Now,
                                                PayPerTask = 100 },
                new EmployeeTasksViewModel() { EmployeeTaskId = 1, EmployeeId = 2, TaskId = 1, TotalNoOfHours = 2, Priority = "Low",
                                                CurrentDate = DateTime.Now, StartDate  = DateTime.Now, EndDate = DateTime.Now,
                                                PayPerTask = 100 },
                new EmployeeTasksViewModel() { EmployeeTaskId = 1, EmployeeId = 2, TaskId = 1, TotalNoOfHours = 2, Priority = "High",
                                                CurrentDate = DateTime.Now, StartDate  = DateTime.Now, EndDate = DateTime.Now,
                                                PayPerTask = 100 },
                new EmployeeTasksViewModel() { EmployeeTaskId = 1, EmployeeId = 3, TaskId = 1, TotalNoOfHours = 2, Priority = "High",
                                                CurrentDate = DateTime.Now, StartDate  = DateTime.Now, EndDate = DateTime.Now,
                                                PayPerTask = 100 }

            };
            return employeeTaskData;
        }



        public EmployeeViewModel GetEmployeeDataDelete()
        {
            int UserId = 0;
            EmployeeViewModel empData = new EmployeeViewModel();

            for (int i = 0; i < 6; i++)
            {
                UserId = i;
                empData.EmployeeId = UserId;
                empData.FirstName = "FirstNameUser" + UserId;
                empData.MiddleName = "MiddleNameUser" + UserId;
                empData.Surname = "SurnameUser" + UserId;
                empData.MobileNo = "";
                empData.EmailAddress = "User" + UserId + "@gmail.com";
                empData.PhysicalAddress = "User" + UserId + "s Physical Addr";
                empData.AccessCode = "User" + UserId + "AccessCode";
                empData.EmployeeRoleCategory = EmployeeRoleCategory.CasualEmployeeLevel1;
            }
            return empData;
        }
    }
}
