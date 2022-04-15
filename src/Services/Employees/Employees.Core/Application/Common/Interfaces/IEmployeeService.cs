using Common.Data.Helpers;
using Employees.Core.Application.Common.Dtos;
using Employees.Core.Domain.Entities;

namespace Employees.Core.Application.Common.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployee(EmployeeToCreateDto dto, CancellationToken cancellationToken);

        Task<Employee> GetEmployeeById(Guid id, CancellationToken cancellationToken);

        Task<Employee> UpdateEmployee(EmployeeToUpdateDto dto, CancellationToken cancellationToken);

        Task DeleteEmployee(Guid id, CancellationToken cancellationToken);

        Task<PaginatedList<Employee>> GetEmployees(int pageIndex, int pageSize, CancellationToken cancellationToken);  
    
        Task<PaginatedList<Employee>> SearchEmployees(string pattern, int pageIndex, int pageSize, CancellationToken cancellationToken);
    }
}
