using Newtonsoft.Json;

namespace Algolia.Core.Domain.Models
{
    public class AlgoliaLocationCounty
    {
        [JsonProperty("default")]
        public List<string> Default { get; set; }
    }
}
