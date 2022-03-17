namespace Trips.Core.Domain.Entities
{
    public class TripGoal : AuditableEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<TripTripGoal> TripTripGoals { get; set; }
    }
}
