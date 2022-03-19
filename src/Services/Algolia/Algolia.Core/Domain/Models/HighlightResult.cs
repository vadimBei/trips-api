using Newtonsoft.Json;

namespace Algolia.Core.Domain.Models
{
    public class HighlightResult
    {
        [JsonProperty(PropertyName = "country")]
        public HighlightResultCountry Country { get; set; }

        [JsonProperty(PropertyName = "postcode")]
        public List<HighlightResultPostcode> Postcodes { get; set; }

        [JsonProperty(PropertyName = "administrative")]
        public List<HighlightResultAdministrative> Administrative { get; set; }

        [JsonProperty(PropertyName = "locale_names")]
        public List<HighlightResultLocaleName> LocaleNames { get; set; }
    }
}
