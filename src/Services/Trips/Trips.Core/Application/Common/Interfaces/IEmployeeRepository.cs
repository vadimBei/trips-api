using Trips.Core.Domain.Models;

namespace Trips.Core.Application.Common.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeById(Guid employeeId, CancellationToken cancellationToken);
    }
}
