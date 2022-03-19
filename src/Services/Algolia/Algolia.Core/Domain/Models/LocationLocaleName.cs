using Newtonsoft.Json;

namespace Algolia.Core.Domain.Models
{
    public class LocationLocaleName
    {
        [JsonProperty(PropertyName = "default")]
        public List<string> Default { get; set; }

        [JsonProperty(PropertyName = "es")]
        public List<string> ES { get; set; }

        [JsonProperty(PropertyName = "en")]
        public List<string> EN { get; set; }

        [JsonProperty(PropertyName = "de")]
        public List<string> DE { get; set; }

        [JsonProperty(PropertyName = "ar")]
        public List<string> AR { get; set; }

        [JsonProperty(PropertyName = "fr")]
        public List<string> FR { get; set; }

        [JsonProperty(PropertyName = "hu")]
        public List<string> HU { get; set; }

        [JsonProperty(PropertyName = "it")]
        public List<string> IT { get; set; }

        [JsonProperty(PropertyName = "ja")]
        public List<string> JA { get; set; }

        [JsonProperty(PropertyName = "nl")]
        public List<string> NL { get; set; }

        [JsonProperty(PropertyName = "pl")]
        public List<string> PL { get; set; }

        [JsonProperty(PropertyName = "pt")]
        public List<string> PT { get; set; }

        [JsonProperty(PropertyName = "ro")]
        public List<string> RO { get; set; }

        [JsonProperty(PropertyName = "ru")]
        public List<string> RU { get; set; }

        [JsonProperty(PropertyName = "zh")]
        public List<string> ZH { get; set; }
    }
}
