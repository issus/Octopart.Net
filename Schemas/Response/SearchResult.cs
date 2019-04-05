using Newtonsoft.Json;

namespace Octopart.Net.Schemas.Response
{
    public class SearchResult
    {
        /// <summary>
        /// A matched object (e.g. a brand)
        /// </summary>
        [JsonProperty("item")]
        public object Item { get; set; }
    }
}
