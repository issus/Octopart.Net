using Newtonsoft.Json;

namespace Octopart.Net.Schemas.Response
{
    public class SearchStatsResult
    {
        /// <summary>
        /// Minimum value of the property in result set
        /// </summary>
        [JsonProperty("mine")]
        public string Min { get; set; }
        /// <summary>
        /// Maximum value of the property in result set
        /// </summary>
        [JsonProperty("max")]
        public string Max { get; set; }
        /// <summary>
        /// Mean value of the property in result set
        /// </summary>
        [JsonProperty("mean")]
        public string Mean { get; set; }
        /// <summary>
        /// Standard deviation of the property values in result set
        /// </summary>
        [JsonProperty("stddev")]
        public string StdDev { get; set; }
        /// <summary>
        /// Number of non-null property values in result set
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }
        /// <summary>
        /// Number of items in result set without a property value
        /// </summary>
        [JsonProperty("missing")]
        public int MissingItems { get; set; }
        /// <summary>
        /// Rank in specs drilldown (useful for ordering filter options)
        /// </summary>
        [JsonProperty("spec_drilldown_rank")]
        public int SpecDrilldownRank { get; set; }

    }
}
