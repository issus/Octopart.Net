using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopart.Net.Schemas.Objects
{
    public class ExternalLinks
    {
        /// <summary>
        /// The url of the Manufacturer's part detail page
        /// </summary>
        [JsonProperty("product_url")]
        public string ProductUrl { get; set; }

        /// <summary>
        /// The url of the Manufacturer's free sample page
        /// </summary>
        [JsonProperty("freesample_url")]
        public string FreeSampleUrl { get; set; }

        /// <summary>
        /// The url of the Manufacturer's eval kit page
        /// </summary>
        [JsonProperty("evalkit_url")]
        public string EvalKitUrl { get; set; }

    }
}
