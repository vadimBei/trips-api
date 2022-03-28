using Newtonsoft.Json;

namespace Algolia.Core.Domain.Models
{
    public class HighlightResultPostcode
    {
        [JsonProperty(PropertyName = "postcode")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "matchLevel")]
        public string MatchLevel { get; set; }

        [JsonProperty(PropertyName = "matchedWords")]
        public List<string> MatchedWords { get; set; }
    }
}
