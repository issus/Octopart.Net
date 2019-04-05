using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopart.Net.Schemas.Objects
{
    public class Part
    {
        /// <summary>
        /// 64-bit unique identifier
        /// </summary>
        [JsonProperty("uid")]
        public string UId { get; set; }

        /// <summary>
        /// The manufacturer part number
        /// </summary>
        [JsonProperty("mpn")]
        public string ManufacturerPartNumber { get; set; }
        /// <summary>
        /// Object representing the manufacturer
        /// </summary>
        [JsonProperty("manufacturer")]
        public Manufacturer Manufacturer { get; set; }
        /// <summary>
        /// Object representing the brand
        /// </summary>
        [JsonProperty("brand")]
        public Brand Brand { get; set; }

        /// <summary>
        /// The url of the Octopart part detail page
        /// </summary>
        [JsonProperty("octopart_url")]
        public string OctopartUrl { get; set; }
        [JsonProperty("external_links")]
        public ExternalLinks ExternalLinks { get; set; }

        /// <summary>
        /// List of offer objects
        /// </summary>
        [JsonProperty("offers")]
        public List<PartOffer> Offers { get; set; }
        [JsonProperty("broker_listings")]
        public List<BrokerListing> BrokerListing { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }
        [JsonProperty("descriptions")]
        public List<Description> Descriptions { get; set; }
        [JsonProperty("imagesets")]
        public List<ImageSet> ImageSets { get; set; }

        [JsonProperty("datasheets")]
        public List<Datasheet> Datasheets { get; set; }
        [JsonProperty("compliance_documents")]
        public List<ComplianceDocument> ComplianceDocuments { get; set; }
        [JsonProperty("reference_designs")]
        public List<ReferenceDesign> ReferenceDesigns { get; set; }
        [JsonProperty("cad_models")]
        public List<CadModel> CadModels { get; set; }

        [JsonProperty("specs")]
        public Dictionary<string, SpecValue> Specs { get; set; }
        [JsonProperty("category_uids")]
        public List<string> CategoryUIds { get; set; }

        public override string ToString()
        {
            return String.Format("{0} by {1} - UID: {2}", ManufacturerPartNumber ?? "unknown", Manufacturer?.Name ?? "unknown", UId);
        }
    }
}
