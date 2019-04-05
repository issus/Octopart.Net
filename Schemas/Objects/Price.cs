using Newtonsoft.Json;
using Octopart.Net.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopart.Net.Schemas.Objects
{
    [JsonConverter(typeof(PartPriceConverter))]
    public class Price
    {
        public Price()
        {
            PriceBreaks = new Dictionary<int, decimal>();
        }

        public string Currency { get; set; }
        public Dictionary<int, decimal> PriceBreaks { get; set; }
    }
}
