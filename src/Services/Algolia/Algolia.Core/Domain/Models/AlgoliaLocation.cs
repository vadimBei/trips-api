using Newtonsoft.Json;

namespace Algolia.Core.Domain.Models
{
    public class AlgoliaLocation
    {
        [JsonProperty(PropertyName = "is_city")]
        public bool IsCity { get; set; }

        [JsonProperty(PropertyName = "is_highway")]
        public bool IsHighway { get; set; }

        [JsonProperty(PropertyName = "locale_names")]
        public LocationLocaleName LocaleNames { get; set; }

        [JsonProperty(PropertyName = "county")]
        public AlgoliaLocationCounty County { get; set; }

        [JsonProperty(PropertyName = "administrative")]
        public List<string> Administrative { get; set; }

        [JsonProperty(PropertyName = "postcode")]
        public List<string> Postcode { get; set; }

        [JsonProperty(PropertyName = "country_code")]
        public string CountryCode { get; set; }

        [JsonProperty(PropertyName = "_tags")]
        public List<string> Tags { get; set; }

        [JsonProperty(PropertyName = "_geoloc")]
        public Geoloc Geoloc { get; set; }

        [JsonProperty(PropertyName = "country")]
        public LocationCountry Country { get; set; }

        [JsonProperty(PropertyName = "population")]
        public long Population { get; set; }

        [JsonProperty(PropertyName = "objectID")]
        public string ObjectID { get; set; }
    }
}
