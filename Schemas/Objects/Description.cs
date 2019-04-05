using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopart.Net.Schemas.Objects
{
    public class Description
    {
        /// <summary>
        /// The value of the description
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// Information about the data source
        /// </summary>
        [JsonProperty("attribution")]
        public Attribution Attribution { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
