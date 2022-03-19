using Newtonsoft.Json;

namespace Algolia.Core.Domain.Models
{
    public class Hit
    {
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "is_country")]
        public bool IsCountry { get; set; }

        [JsonProperty(PropertyName = "is_highway")]
        public bool IsHighway { get; set; }

        [JsonProperty(PropertyName = "importance")]
        public int Importance { get; set; }

        [JsonProperty(PropertyName = "_tags")]
        public List<string> Tags { get; set; }

        [JsonProperty(PropertyName = "postcode")]
        public List<string> Postcode { get; set; }

        [JsonProperty(PropertyName = "county")]
        public List<string> County { get; set; }

        [JsonProperty(PropertyName = "population")]
        public long Population { get; set; }

        [JsonProperty(PropertyName = "country_code")]
        public string CountryCode { get; set; }

        [JsonProperty(PropertyName = "is_city")]
        public bool IsCity { get; set; }

        [JsonProperty(PropertyName = "is_popular")]
        public bool IsPopular { get; set; }

        [JsonProperty(PropertyName = "administrative")]
        public List<string> Administrative { get; set; }

        [JsonProperty(PropertyName = "admin_level")]
        public int AdminLevel { get; set; }

        [JsonProperty(PropertyName = "is_suburb")]
        public bool IsSuburb { get; set; }

        [JsonProperty(PropertyName = "locale_names")]
        public List<string> LocaleNames { get; set; }

        [JsonProperty(PropertyName = "_geoloc")]
        public Geoloc Geoloc { get; set; }

        [JsonProperty(PropertyName = "objectID")]
        public string ObjectID { get; set; }

        [JsonProperty(PropertyName = "_highlightResult")]
        public HighlightResult HighlightResult { get; set; }
    }
}