using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.ViewModels
{
    public class GetTestData
    {
        public EmployeeViewModel GetEmployeeData()
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
