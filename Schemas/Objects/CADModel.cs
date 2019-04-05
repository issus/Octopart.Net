using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopart.Net.Schemas.Objects
{
    public class CadModel : Asset
    {
        /// <summary>
        /// Information about the data source
        /// </summary>
        [JsonProperty("attribution")]
        public Attribution Attribution { get; set; }
    }
}
