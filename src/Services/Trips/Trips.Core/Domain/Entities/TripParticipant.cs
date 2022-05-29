using System.ComponentModel.DataAnnotations.Schema;
using Trips.Core.Domain.Models;

namespace Trips.Core.Domain.Entities
{
    public class TripParticipant : AuditableEntity
    {
        public long Id { get; set; }

        public long TripId { get; set; }

        public Guid EmployeeId { get; set; }

        [NotMapped]
        public Employee Employee { get; set; }
    }
}
