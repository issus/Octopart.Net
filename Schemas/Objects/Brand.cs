using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopart.Net.Schemas.Objects
{
    public class Brand
    {
        /// <summary>
        /// 64-bit unique identifier
        /// </summary>
        [JsonProperty("uid")]
        public string UId { get; set; }
        /// <summary>
        /// The brand's display name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The brand's homepage url
        /// </summary>
        [JsonProperty("homepage_url")]
        public string HomepageUrl { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
