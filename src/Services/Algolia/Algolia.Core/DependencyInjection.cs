using Algolia.Core.Application.Common.Interfaces;
using Algolia.Core.Application.Common.Services;
using Algolia.Core.Infrastructure;
using Algolia.Core.Infrastructure.Repositories;
using Common.Data;
using Common.Kernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Algolia.Core
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
            services.AddTransient<IAlgoliaService, AlgoliaService>();

            // add application repositories
            services.AddTransient<IAlgoliaRepository, AlgoliaRepository>();

            return services;
        }
    }
}
