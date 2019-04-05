using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopart.Net.Schemas.Objects
{
    public class Attribution
    {
        /// <summary>
        /// List of source objects
        /// </summary>
        [JsonProperty("sources")]
        public List<Source> Sources { get; set; }
        /// <summary>
        /// ISO 8601 formatted time when data was acquired
        /// </summary>
        [JsonProperty("first_acquired")]
        public DateTime? FirstAcquired { get; set; }

    }
}
