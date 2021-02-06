using EmployeeManagementPortal.MVC.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddHttpClient<IEmployeeManagementService, EmployeeManagementService>();


            return services;
        }
    }
}
