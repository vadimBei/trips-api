using Common.Data.WebClient.Extensions;
using Common.Data.WebClient.Interfaces;
using Trips.Core.Application.Common.Interfaces;
using Trips.Core.Domain.Models;

namespace Trips.Core.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IWebClient _webClient;

        public EmployeeRepository(
            IWebClient webClient)
        {
            _webClient = webClient;
            _webClient.Configure(x =>
            {
                x.WebResourcePath = "employees-api/employees-service";
            });
        }

        public async Task<Employee> GetEmployeeById(Guid employeeId, CancellationToken cancellationToken)
        {
            var employee = await _webClient
                .Get<Employee>($"by-id/{employeeId}", cancellationToken);

            return employee;
        }
    }
}
