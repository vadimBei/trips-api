using Algolia.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Algolia.Core.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Location> Locations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
