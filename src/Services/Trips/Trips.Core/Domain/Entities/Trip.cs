using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trips.Core.Domain.Enums;
using Trips.Core.Domain.Models;

namespace Trips.Core.Domain.Entities
{
    public class Trip : AuditableEntity
    {
        public long Id { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public string Comment { get; set; }

        public string Goal { get; set; }

        public TripType Type { get; set; }

        public TripStatus Status { get; set; }

        public TripVehicleType VehicleType { get; set; }

        public Guid AuthorId { get; set; }

        [NotMapped]
        public Employee Author { get; set; }

        public Guid? ApprovedEmployeeId { get; set; }

        [NotMapped]
        public Employee ApprovedEmployee { get; set; }

        public List<TripLocation> Locations { get; set; }

        public List<TripParticipant> Participants { get; set; }
    }
}
