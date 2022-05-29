using Microsoft.EntityFrameworkCore;
using Trips.Core.Domain.Entities;

namespace Trips.Core.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Trip> Trips { get; set; }

        DbSet<TripLocation> TripLocations { get; set; }

        DbSet<TripParticipant> TripParticipants { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
