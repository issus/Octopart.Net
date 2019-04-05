using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopart.Net.Schemas.Response
{
    public class PartsMatchRequest
    {
        /// <summary>
        /// List of queries
        /// </summary>
        [JsonProperty("queries")]
        public List<PartsMatchQuery> Queries { get; set; }

        /// <summary>
        /// Match on non-alphanumeric characters in part numbers
        /// </summary>
        [JsonProperty("exact_only")]
        public bool ExactOnly { get; set; }
    }
}
