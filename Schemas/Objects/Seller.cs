using Newtonsoft.Json;

namespace Octopart.Net.Schemas.Objects
{
    public class Seller
    {
        /// <summary>
        /// 64-bit unique identifier
        /// </summary>
        [JsonProperty("uid")]
        public string UId { get; set; }
        /// <summary>
        /// The seller's display name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The seller's homepage url
        /// </summary>
        [JsonProperty("homepage_url")]
        public string HomepageUrl { get; set; }
        /// <summary>
        /// ISO 3166 alpha-2 country code for display flag
        /// </summary>
        [JsonProperty("display_flag")]
        public string DisplayFlag { get; set; }
        /// <summary>
        /// Whether seller has e-commerce
        /// </summary>
        [JsonProperty("has_ecommerce")]
        public string HasECommerce { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
