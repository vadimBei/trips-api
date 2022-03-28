using Trips.Core.Domain.Enums;

namespace Trips.Core.Domain.Entities
{
    public class Trip : AuditableEntity
    {
        public long Id { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public DateTime ApprovedDate { get; set; }

        public string Comment { get; set; }

        public string Goal { get; set; }

        public long? ApprovedEmployeeId { get; set; }

        //public Employee ApprovedEmployee { get; set; }

        public TripType Type { get; set; }

        public TripStatus Status { get; set; }

        public bool ApprovedByTripCurator { get; set; }

        public bool IsDeleted { get; set; }

        public List<TripLocation> Locations { get; set; }

        public List<TripParticipant> Participants { get; set; }

        public List<TripTripGoal> TripTripGoals { get; set; }

        public TripVehicleType VehicleType { get; set; }
    }
}
