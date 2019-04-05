using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Octopart.Net.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopart.Net.Schemas.Objects
{
    public class ComplianceDocument : Asset
    {
        /// <summary>
        /// List of document classifications
        /// </summary>
        [JsonProperty("subtypes")]
        [JsonConverter(typeof(ComplianceSubTypeConverter))]
        public ComplianceSubType SubTypes { get; set; }
        /// <summary>
        /// 	Information about the data source
        /// </summary>
        [JsonProperty("attribution")]
        public Attribution Attribution { get; set; }
    }

    public enum ComplianceSubType
    {
        RohsStatement,
        ReachStatement,
        MaterialsSheet,
        ConflictMineralStatement
    }
}
