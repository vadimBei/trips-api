using Newtonsoft.Json;

namespace Algolia.Core.Domain.Models
{
    public class LocationCountry
    {
        [JsonProperty(PropertyName = "ar")]
        public string AR { get; set; }

        [JsonProperty(PropertyName = "de")]
        public string DE { get; set; }

        [JsonProperty(PropertyName = "default")]
        public string Default { get; set; }

        [JsonProperty(PropertyName = "es")]
        public string ES { get; set; }

        [JsonProperty(PropertyName = "fr")]
        public string FR { get; set; }

        [JsonProperty(PropertyName = "hu")]
        public string HU { get; set; }

        [JsonProperty(PropertyName = "it")]
        public string IT { get; set; }

        [JsonProperty(PropertyName = "ja")]
        public string JA { get; set; }

        [JsonProperty(PropertyName = "en")]
        public string EN { get; set; }

        [JsonProperty(PropertyName = "nl")]
        public string NL { get; set; }

        [JsonProperty(PropertyName = "pl")]
        public string PL { get; set; }

        [JsonProperty(PropertyName = "pt")]
        public string PT { get; set; }

        [JsonProperty(PropertyName = "ro")]
        public string RO { get; set; }

        [JsonProperty(PropertyName = "ru")]
        public string RU { get; set; }

        [JsonProperty(PropertyName = "zh")]
        public string ZH { get; set; }
    }
}
