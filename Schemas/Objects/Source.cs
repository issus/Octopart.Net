using Newtonsoft.Json;

namespace Octopart.Net.Schemas.Objects
{
    public class Source
    {
        /// <summary>
        /// 64-bit unique identifier
        /// </summary>
        [JsonProperty("uid")]
        public string UId { get; set; }
        /// <summary>
        /// The source's display name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
