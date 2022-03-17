namespace Trips.Core.Domain.Entities
{
    public class TripTripGoal : AuditableEntity
    {
        public long Id { get; set; }

        public long TripId { get; set; }
        public Trip Trip { get; set; }

        public long TripGoalId { get; set; }
        public TripGoal TripGoal { get; set; }
    }
}
