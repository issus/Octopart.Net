using Newtonsoft.Json;
using System;

namespace Octopart.Net.Schemas.Response
{
    public class PartsMatchQuery
    {
        public PartsMatchQuery()
        {
            Reference = Guid.NewGuid().ToString();
            Start = 0;
            Limit = 20;
        }

        /// <summary>
        /// Free-form keyword query
        /// </summary>
        [JsonProperty("q")]
        public string Query { get; set; }

        /// <summary>
        /// MPN search filter (See notes: Part Number Filters)
        /// </summary>
        [JsonProperty("mpn")]
        public string ManufacturerPartNumber { get; set; }

        /// <summary>
        /// Brand search filter
        /// </summary>
        [JsonProperty("brand")]
        public string Brand { get; set; }

        /// <summary>
        /// SKU search filter (See notes: Part Number Filters)
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Seller search filter
        /// </summary>
        [JsonProperty("seller")]
        public string Seller { get; set; }

        /// <summary>
        /// MPN or SKU search filter (See notes: Part Number Filters)
        /// </summary>
        [JsonProperty("mpn_or_sku")]
        public string ManufacturerPartOrSku { get; set; }

        /// <summary>
        /// Ordinal position of first returned item
        /// </summary>
        [JsonProperty("start")]
        public int Start { get; set; }
        /// <summary>
        /// Maximum number of items to return
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Arbitrary string for identifying results
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; set; }

    }
}