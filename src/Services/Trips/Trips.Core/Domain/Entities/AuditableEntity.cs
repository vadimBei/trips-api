namespace Trips.Core.Domain.Entities
{
    public class AuditableEntity
    {
        public DateTime DateOfCreation { get; set; }

        public DateTime DateOfModification { get; set; }
    }
}
