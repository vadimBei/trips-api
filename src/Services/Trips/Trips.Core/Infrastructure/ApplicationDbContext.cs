using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Trips.Core.Application.Common.Interfaces;
using Trips.Core.Domain.Entities;

namespace Trips.Core.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Trip> Trips { get; set; }

        public DbSet<TripLocation> TripLocations { get; set; }

        public DbSet<TripParticipant> TripParticipants { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }       

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
