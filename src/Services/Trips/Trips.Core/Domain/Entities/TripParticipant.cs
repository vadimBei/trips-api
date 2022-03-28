namespace Trips.Core.Domain.Entities
{
    public class TripParticipant : AuditableEntity
    {
        public long Id { get; set; }
        public long TripId { get; set; }
        public long EmployeeId { get; set; }
        //public Employee Employee { get; set; }
    }
}
