using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopart.Net.Schemas.Objects
{
    public class Category
    {
        /// <summary>
        /// 64-bit unique identifier
        /// </summary>
        [JsonProperty("uid")]
        public string UId { get; set; }

        /// <summary>
        /// The category node's name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 64-bit unique identifier of parent category node
        /// </summary>
        [JsonProperty("parent_uid")]
        public string ParentUId { get; set; }

        /// <summary>
        /// JSON array of children uid's
        /// </summary>
        [JsonProperty("children_uids")]
        public List<string> ChildrenUIds { get; set; }

        /// <summary>
        /// JSON array of ancestor uid's with parent ordered last
        /// </summary>
        [JsonProperty("ancestor_uids")]
        public List<string> AncestorUIds { get; set; }
        /// <summary>
        /// JSON array of ancestor node names
        /// </summary>
        [JsonProperty("ancestor_names")]
        public List<string> AncestorNames { get; set; }

        /// <summary>
        /// Number of parts categorized in category node
        /// </summary>
        [JsonProperty("num_parts")]
        public int NumParts { get; set; }

        /// <summary>
        /// Hidden by default (See Include Directives)
        /// </summary>
        [JsonProperty("imagesets")]
        public List<ImageSet> ImageSets { get; set; }
    }
}
