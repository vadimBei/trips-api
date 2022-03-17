using Employees.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employees.Core.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Employee> Employees { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}   
