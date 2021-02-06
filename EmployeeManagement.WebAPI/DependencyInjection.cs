using EmployeeManagement.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.WebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<LearnNowContext>(opt => opt
                .UseSqlServer("Server=tcp:at-learnnowapp-dev.database.windows.net,1433;Initial Catalog=AT-LearnNowApp-Dev;Persist Security Info=False;User ID=learnnowuser;Password=Passw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            return services;
        }
    }
}
