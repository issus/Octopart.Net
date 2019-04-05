using Newtonsoft.Json;
using System.Collections.Generic;

namespace Octopart.Net.Schemas.Response
{
    public class SearchFacetResult
    {
        /// <summary>
        /// List of value/count JSON objects
        /// </summary>
        [JsonProperty("facets")]
        public List<FacetResultItem> Facets { get; set; }
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
