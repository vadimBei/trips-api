using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Common.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services, Assembly executingAssembly, IConfiguration configuration)
        {
            // register common components
            services.AddAutoMapper(executingAssembly, Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(executingAssembly);

            return services;
        }
    }
}
