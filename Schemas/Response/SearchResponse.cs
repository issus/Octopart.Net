using Newtonsoft.Json;
using System.Collections.Generic;

namespace Octopart.Net.Schemas.Response
{
    public class SearchResponse
    {
        /// <summary>
        /// The original request
        /// </summary>
        [JsonProperty("request")]
        public SearchRequest Request { get; set; }

        /// <summary>
        /// List of search results
        /// </summary>
        [JsonProperty("results")]
        public List<SearchResult> Results { get; set; }
        /// <summary>
        /// Total number of matched items
        /// </summary>
        [JsonProperty("hits")]
        public int Hits { get; set; }

        /// <summary>
        /// The server response time in milliseconds
        /// </summary>
        [JsonProperty("msec")]
        public int ResponseTime { get; set; }

        // -------------- TBD -----------------
        // todo: Need to figure out how to handle this
        /// <summary>
        /// See: Search Documentation
        /// </summary>
        [JsonProperty("facet_results")]
        public string FacetResults { get; set; }
        /// <summary>
        /// See: Search Documentation
        /// </summary>
        [JsonProperty("stats_results")]
        public string StatsResults { get; set; }
        /// <summary>
        /// See: Search Documentation
        /// </summary>
        [JsonProperty("spec_metadata")]
        public string SpecMetadata { get; set; }
    }
}
