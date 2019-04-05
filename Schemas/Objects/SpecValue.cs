using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Octopart.Net.Schemas.Objects
{
    public class SpecValue
    {
        /// <summary>
        /// The value of the product property
        /// </summary>
        [JsonProperty("value")]
        public List<string> Value { get; set; }
        /// <summary>
        /// The minimum value (if ranged quantitative value)
        /// </summary>
        [JsonProperty("min_value")]
        public string MinValue { get; set; }
        /// <summary>
        /// The maximum value (if ranged quantitative value)
        /// </summary>
        [JsonProperty("max_value")]
        public string MaxValue { get; set; }
        /// <summary>
        /// Spec metadata information
        /// </summary>
        [JsonProperty("metadata")]
        public SpecMetadata Metadata { get; set; }
        /// <summary>
        /// Information about the data source
        /// </summary>
        [JsonProperty("attribution")]
        public Attribution Attribution { get; set; }

        public override string ToString()
        {
            if (Value.Count == 1)
                return Value[0];
            else if (Value.Count == 0)
                return "no value";
            else
                return String.Format("{0} (+{1} others)", Value[0], Value.Count - 1);
        }
    }

    public enum OctoDataType
    {
        String,
        Integer,
        Decimal
    }
}