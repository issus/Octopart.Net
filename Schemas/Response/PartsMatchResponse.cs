using Newtonsoft.Json;
using System.Collections.Generic;

namespace Octopart.Net.Schemas.Response
{
    public class PartsMatchResponse
    {
        /// <summary>
        /// The original request
        /// </summary>
        [JsonProperty("request")]
        public PartsMatchRequest Request { get; set; }

        /// <summary>
        /// List of query results
        /// </summary>
        [JsonProperty("results")]
        public List<PartsMatchResult> Results { get; set; }

        /// <summary>
        /// The server response time in milliseconds
        /// </summary>
        [JsonProperty("msec")]
        public int ResponseTime { get; set; }
    }
}
