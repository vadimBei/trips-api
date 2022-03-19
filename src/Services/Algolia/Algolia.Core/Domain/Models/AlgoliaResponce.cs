using Newtonsoft.Json;

namespace Algolia.Core.Domain.Models
{
    public class AlgoliaResponce
    {
        [JsonProperty(PropertyName = "hits")]
        public List<Hit> Hits { get; set; }

        [JsonProperty(PropertyName = "nbHits")]
        public int NbHits { get; set; }

        [JsonProperty(PropertyName = "processingTimeMS")]
        public int ProcessingTimeMS { get; set; }

        [JsonProperty(PropertyName = "query")]
        public string Query { get; set; }

        [JsonProperty(PropertyName = "params")]
        public string Params { get; set; }

        [JsonProperty(PropertyName = "degradedQuery")]
        public bool DegradedQuery { get; set; }
    }
}
