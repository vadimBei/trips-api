namespace Trips.Core.Domain.Entities
{
    public class TripLocation : AuditableEntity
    {
        public long Id { get; set; }

        public long TripId { get; set; }

        public string ObjectId { get; set; }

        public string Administrative { get; set; }

        public string CountryCode { get; set; }

        public string Country { get; set; }

        public List<string> County { get; set; }

        public string Name { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }
    }
}
