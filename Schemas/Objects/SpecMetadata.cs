using Newtonsoft.Json;

namespace Octopart.Net.Schemas.Objects
{
    public class SpecMetadata
    {
        /// <summary>
        /// Immutable identifier of property in Part.specs object
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }
        /// <summary>
        /// The name of the product property
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("datatype")]
        public OctoDataType DataType { get; set; }
        /// <summary>
        /// 	UnitOfMeasurement object
        /// </summary>
        [JsonProperty("unit")]
        public UnitOfMeasurement Unit { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}