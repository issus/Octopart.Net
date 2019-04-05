using Newtonsoft.Json;

namespace Octopart.Net.Schemas.Objects
{
    public class UnitOfMeasurement
    {
        /// <summary>
        /// The name of the unit of measurement
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The symbol of the unit of measurement
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}