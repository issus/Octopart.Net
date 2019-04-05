using Newtonsoft.Json;
using System;

namespace Octopart.Net.Schemas.Objects
{
    public class Asset
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("mimetype")]
        public string MimeType { get; set; }

        [JsonProperty("metadata")]
        public MetaData Metadata { get; set; }

        public class MetaData
        {
            /// <summary>
            /// Asset File Size in Bytes
            /// </summary>
            [JsonProperty("size_bytes")]
            public int? SizeBytes { get; set; }

            /// <summary>
            /// Number of pages in a PDF
            /// </summary>
            [JsonProperty("num_pages")]
            public int? NumPages { get; set; }

            /// <summary>
            /// Date asset was created
            /// </summary>
            [JsonProperty("date_created")]
            public DateTime? DateCreated { get; set; }
            /// <summary>
            /// Date asset was last modified
            /// </summary>
            [JsonProperty("last_modified")]
            public DateTime? LastModified { get; set; }

            /// <summary>
            /// Image Width for image/gif, image/jpeg, image/png
            /// </summary>
            [JsonProperty("width")]
            public int? Width { get; set; }
            /// <summary>
            /// ImageHeight for image/gif, image/jpeg, image/png
            /// </summary>
            [JsonProperty("height")]
            public int? Height { get; set; }
        }
    }
}
