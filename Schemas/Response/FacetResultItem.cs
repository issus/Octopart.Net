using Newtonsoft.Json;

namespace Octopart.Net.Schemas.Response
{
    public class FacetResultItem
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
