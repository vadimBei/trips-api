using Trips.Core.Domain.Models;

namespace Trips.Core.Application.Common.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeById(Guid employeeId, CancellationToken cancellationToken);
    }
}
