using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopart.Net.Schemas.Objects
{
    public class BrokerListing
    {
        /// <summary>
        /// Object representing the seller
        /// </summary>
        [JsonProperty("seller")]
        public Seller Seller { get; set; }
        /// <summary>
        /// URL for listing
        /// </summary>
        [JsonProperty("listing_url")]
        public string ListingUrl { get; set; }
        /// <summary>
        /// URL for generating RFQ through Octopart
        /// </summary>
        [JsonProperty("ocotopart_rfq_url")]
        public string OcotopartRfqUrl { get; set; }
    }
}
