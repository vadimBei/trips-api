using Trips.Core.Application.Common.Interfaces;
using Trips.Core.Domain.Models;

namespace Trips.Core.Application.Common.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(
            IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> GetEmployeeById(Guid employeeId, CancellationToken cancellationToken)
        {
            return await _employeeRepository
                .GetEmployeeById(employeeId, cancellationToken);
        }
    }
}
