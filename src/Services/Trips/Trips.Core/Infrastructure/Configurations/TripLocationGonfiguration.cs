using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trips.Core.Domain.Entities;

namespace Trips.Core.Infrastructure.Configurations
{
    public class TripLocationGonfiguration : IEntityTypeConfiguration<TripLocation>
    {
        public void Configure(EntityTypeBuilder<TripLocation> builder)
        {
            builder.ToTable("TripLocations");
        }
    }
}
