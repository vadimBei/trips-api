using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trips.Core.Domain.Entities;

namespace Trips.Core.Infrastructure.Configurations
{
    public class TripParticipantGonfiguration : IEntityTypeConfiguration<TripParticipant>
    {
        public void Configure(EntityTypeBuilder<TripParticipant> builder)
        {
            builder.ToTable("TripParticipants");
        }
    }
}
