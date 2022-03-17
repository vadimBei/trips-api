using Common.Data;
using Common.Kernel;
using Employees.Core.Application.Common.Interfaces;
using Employees.Core.Application.Common.Services;
using Employees.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Employees.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddKernel(Assembly.GetExecutingAssembly(), configuration);
            services.AddData(Assembly.GetExecutingAssembly(), configuration);

            // add infrastructure
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            // add application services
            services.AddTransient<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
