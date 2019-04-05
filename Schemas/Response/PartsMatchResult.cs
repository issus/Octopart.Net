using Newtonsoft.Json;
using Octopart.Net.Schemas.Objects;
using System.Collections.Generic;

namespace Octopart.Net.Schemas.Response
{
    public class PartsMatchResult
    {
        /// <summary>
        /// List of matched parts
        /// </summary>
        [JsonProperty("items")]
        public List<Part> Items { get; set; }

        /// <summary>
        /// Total number of matched items
        /// </summary>
        [JsonProperty("hits")]
        public int Hits { get; set; }

        /// <summary>
        /// Reference string specified in query
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; set; }

        /// <summary>
        /// Error message (if applicable)
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
