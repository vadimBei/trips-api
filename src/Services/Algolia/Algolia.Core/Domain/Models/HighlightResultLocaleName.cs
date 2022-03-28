﻿using Newtonsoft.Json;

namespace Algolia.Core.Domain.Models
{
    public class HighlightResultLocaleName
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "matchLevel")]
        public string MatchLevel { get; set; }

        [JsonProperty(PropertyName = "fullyHighlighted")]
        public bool? FullyHighlighted { get; set; }

        [JsonProperty(PropertyName = "matchedWords")]
        public List<string> MatchedWords { get; set; }
    }
}
