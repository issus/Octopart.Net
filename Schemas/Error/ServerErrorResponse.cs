using Newtonsoft.Json;

namespace Octopart.Net.Schemas.Error
{
    public class ServerErrorResponse
    {
        /// <summary>
        /// Message associated with 5XX HTTP response
        /// </summary>
        [JsonProperty("count")]
        public string Message { get; set; }
    }
}
