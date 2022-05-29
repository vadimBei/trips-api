using System.ComponentModel.DataAnnotations.Schema;
using Trips.Core.Domain.Models;

namespace Trips.Core.Domain.Entities
{
    public class TripLocation : AuditableEntity
    {
        public long Id { get; set; }

        public long TripId { get; set; }

        public string ObjectId { get; set; }

        [NotMapped]
        public AlgoliaLocation Location { get; set; }
    }
}
