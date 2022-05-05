using Common.Data;
using Common.Data.WebClient;
using Common.Kernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Trips.Core.Application.Common.Interfaces;
using Trips.Core.Application.Common.Services;
using Trips.Core.Application.Common.Strategies;
using Trips.Core.Infrastructure;
using Trips.Core.Infrastructure.Repositories;

namespace Trips.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddKernel(Assembly.GetExecutingAssembly(), configuration);
            services.AddData(Assembly.GetExecutingAssembly(), configuration);
            services.AddWebClient(configuration);

            // add infrastructure
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            // add application services
            services.AddTransient<IAlgoliaService, AlgoliaService>(); 
            services.AddTransient<IMapperService, MapperService>();
            services.AddTransient<ISieveService, SieveService>();
            services.AddTransient<ITripStrategy, EmployeeTripStrategy>();
            services.AddTransient<ITripStrategy, AdminTripStrategy>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ITripService, TripService>();

            // add application repositories
            services.AddTransient<IAlgoliaRepository, AlgoliaRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
