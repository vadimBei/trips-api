namespace Trips.Core.Domain.Models
{
    public class AlgoliaLocation
    {
        public string ObjectID { get; set; }

        public string Administrative { get; set; }

        public string CountryCode { get; set; }

        public string Country { get; set; }

        public string Name { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public List<string> County { get; set; }
    }
}
