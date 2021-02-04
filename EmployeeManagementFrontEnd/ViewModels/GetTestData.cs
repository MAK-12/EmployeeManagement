using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.ViewModels
{
    public class GetTestData
    {
        public IList<EmployeeViewModel> GetEmployeeData()
        {
            IList<EmployeeViewModel> empData = new List<EmployeeViewModel>()
            {
                new EmployeeViewModel() { EmployeeId = 1, FirstName = "FNameJohn", MiddleName = "MNameJohn", Surname = "SurnameJohn", MobileNo = "1111111", EmailAddress = "John@gmail.com", PhysicalAddress = "USA", AccessCode = "ACC123Jhon", IsPermanentEmployee = EmployeeManagementPortal.MVC.Common.EmploymentType.PermanentEmployee },

               new EmployeeViewModel() { EmployeeId = 2, FirstName = "FNameSteve", MiddleName = "MNameSteve", Surname = "SurnameSteve", MobileNo = "222222222", EmailAddress = "Steve@gmail.com", PhysicalAddress = "UK", AccessCode = "ACC123Jhon", IsPermanentEmployee = EmployeeManagementPortal.MVC.Common.EmploymentType.PermanentEmployee },

               new EmployeeViewModel() { EmployeeId = 3, FirstName = "FNameRam", MiddleName = "MNameRam", Surname = "SurnameRam", MobileNo = "333333333", EmailAddress = "Ram@gmail.com", PhysicalAddress = "IND", AccessCode = "ACC123Jhon", IsPermanentEmployee = EmployeeManagementPortal.MVC.Common.EmploymentType.PermanentEmployee },

               new EmployeeViewModel() { EmployeeId = 4, FirstName = "FNameKrish", MiddleName = "MNameKrish", Surname = "SurnameKrish", MobileNo = "4444444444", EmailAddress = "Krish@gmail.com", PhysicalAddress = "ENGL", AccessCode = "ACC123Jhon", IsPermanentEmployee = EmployeeManagementPortal.MVC.Common.EmploymentType.PermanentEmployee },

               new EmployeeViewModel() { EmployeeId = 5, FirstName = "FNameHarvey", MiddleName = "MNameHarvey", Surname = "SurnameHarvey", MobileNo = "55555555", EmailAddress = "Harvey@gmail.com", PhysicalAddress = "ZIM", AccessCode = "ACC123Jhon", IsPermanentEmployee = EmployeeManagementPortal.MVC.Common.EmploymentType.PermanentEmployee }
            };

            return empData;
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
                empData.IsPermanentEmployee = EmployeeManagementPortal.MVC.Common.EmploymentType.PermanentEmployee;
            }
            return empData;
        }
    }
}
