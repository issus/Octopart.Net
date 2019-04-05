using Newtonsoft.Json;

namespace Octopart.Net.Schemas.Objects
{
    public class ImageSet
    {
        /// <summary>
        /// Asset object representing the image
        /// </summary>
        [JsonProperty("swatch_image")]
        public Asset SwatchImage { get; set; }

        /// <summary>
        /// Asset object representing the image
        /// </summary>
        [JsonProperty("small_image")]
        public Asset SmallImage { get; set; }

        /// <summary>
        /// Asset object representing the image
        /// </summary>
        [JsonProperty("medium_image")]
        public Asset MediumImage { get; set; }

        /// <summary>
        /// Asset object representing the image
        /// </summary>
        [JsonProperty("large_image")]
        public Asset LargeImage { get; set; }


        /// <summary>
        /// Information about the data source
        /// </summary>
        [JsonProperty("attribution")]
        public Attribution Attribution { get; set; }
        /// <summary>
        /// The API Terms of Use require that if you display an image, you must also display its credit string and link to the credit URL
        /// </summary>
        [JsonProperty("credit_string")]
        public string Credit { get; set; }
        /// <summary>
        /// The API Terms of Use require that if you display an image, you must also display its credit string and link to the credit URL
        /// </summary>
        [JsonProperty("credit_url")]
        public string CreditUrl { get; set; }
    }
}