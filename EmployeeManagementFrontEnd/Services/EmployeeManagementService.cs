using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.Services
{
    public class EmployeeManagementService
    {
        private readonly HttpClient httpClient;
        public EmployeeManagementService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
