using Newtonsoft.Json;

namespace Algolia.Core.Domain.Models
{
    public class Geoloc
    {
        [JsonProperty(PropertyName = "lat")]
        public float Latitude { get; set; }


        [JsonProperty(PropertyName = "lng")]
        public float Longitude { get; set; }
    }
}
