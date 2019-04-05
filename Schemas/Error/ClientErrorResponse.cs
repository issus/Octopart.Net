using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopart.Net.Schemas.Error
{
    public class ClientErrorResponse
    {
        /// <summary>
        /// Message associated with 4XX HTTP response
        /// </summary>
        [JsonProperty("count")]
        public string Message { get; set; }
    }
}
