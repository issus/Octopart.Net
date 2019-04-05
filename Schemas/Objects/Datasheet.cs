using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopart.Net.Schemas.Objects
{
    public class Datasheet : Asset
    {
        /// <summary>
        /// Information about the data source
        /// </summary>
        [JsonProperty("imagesets")]
        public Attribution Attribution { get; set; }

        public override string ToString()
        {
            return Url;
        }
    }
}
