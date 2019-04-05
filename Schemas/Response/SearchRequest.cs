using Newtonsoft.Json;

namespace Octopart.Net.Schemas.Response
{
    public class SearchRequest
    {
        /// <summary>
        /// Free-form keyword string
        /// </summary>
        [JsonProperty("q")]
        public string Query { get; set; }

        /// <summary>
        /// Ordinal position of first result
        /// </summary>
        [JsonProperty("start")]
        public int Start { get; set; }

        /// <summary>
        /// Maximum number of results to return
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Comma separated list of (fieldname, fieldorder) pairs
        /// </summary>
        [JsonProperty("sortby")]
        public string SortBy { get; set; }
        
        
        /// <summary>
        /// See: Search Documentation
        /// </summary>
        [JsonProperty("filter")]
        public string Filter { get; set; }
        /// <summary>
        /// See: Search Documentation
        /// </summary>
        [JsonProperty("facet")]
        public string Facet { get; set; }
        /// <summary>
        /// See: Search Documentation
        /// </summary>
        [JsonProperty("stats")]
        public string Stats { get; set; }
    }
}
