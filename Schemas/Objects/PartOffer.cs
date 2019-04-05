using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Octopart.Net.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Octopart.Net.Schemas.Objects
{
    public class PartOffer
    {
        /// <summary>
        /// The seller's part number
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Object representing the seller
        /// </summary>
        [JsonProperty("seller")]
        public Seller Seller { get; set; }

        /// <summary>
        /// The (ISO 3166-1 alpha-2) or (ISO 3166-2) code indicating the geo-political region(s) for which offer is valid
        /// </summary>
        [JsonProperty("eligible_region")]
        public string EligibleRegion { get; set; }

        /// <summary>
        /// URL for seller landing page
        /// </summary>
        [JsonProperty("product_url")]
        public string ProductUrl { get; set; }

        /// <summary>
        /// URL for generating RFQ through Octopart
        /// </summary>
        [JsonProperty("ocotopart_rfq_url")]
        public string OctopartRfqUrl { get; set; }

        [JsonProperty("prices")]
        public Price Prices { get; set; }

        /// <summary>
        /// Number of parts seller has available
        /// </summary>
        [JsonProperty("in_stock_quantity")]
        public int? InStockQuantity { get; set; }
        
        /// <summary>
        /// Number of parts on order from factory
        /// </summary>
        [JsonProperty("on_order_quantity")]
        public int? OnOrderQuantity { get; set; }
        /// <summary>
        /// ETA of order from factory
        /// </summary>
        [JsonProperty("on_order_eta")]
        public DateTime? OnOrderEta { get; set; }

        /// <summary>
        /// Number of days to acquire parts from factory
        /// </summary>
        [JsonProperty("factory_lead_days")]
        public int? FactoryLeadDays { get; set; }
        /// <summary>
        /// Order multiple for factory orders
        /// </summary>
        [JsonProperty("factory_order_multiple")]
        public int? FactoryOrderMultiple { get; set; }

        /// <summary>
        /// Number of items which must be ordered together
        /// </summary>
        [JsonProperty("order_multiple")]
        public int? OrderMultiple { get; set; }
        /// <summary>
        /// Minimum order quantity
        /// </summary>
        [JsonProperty("moq")]
        public int? MinimumOrderQuantity { get; set; }

        /// <summary>
        /// The quantity of parts as packaged by the seller
        /// </summary>
        [JsonProperty("multipack_quantity")]
        public int? MultipackQuantity { get; set; }

        /// <summary>
        /// Form of offer packaging (e.g. reel, tape)
        /// </summary>
        [JsonProperty("packaging")]
        [JsonConverter(typeof(PackagingConverter))]
        public PartOfferPackaging Packaging { get; set; }

        /// <summary>
        /// True if seller is authorized by manufacturer
        /// </summary>
        [JsonProperty("is_authorized")]
        public bool IsAuthorized { get; set; }

        /// <summary>
        /// when offer was last updated by the seller
        /// </summary>
        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }

        public bool NonStocked { get { return InStockQuantity == -1; } }
        public bool StockedWithoutQty { get { return InStockQuantity == -2; } }
        public bool StockQuantityUnknown { get { return InStockQuantity == -3; } }
        public bool StockQuantityRfq { get { return InStockQuantity == -4; } }

        public override string ToString()
        {
            if (Prices?.PriceBreaks?.Count > 0)
            {
                return String.Format("({0}){1} sku {2} - {3} on hand. {4}{5} @{6}", Seller?.DisplayFlag ?? "EH?", Seller?.Name ?? "unknown", Sku, InStockQuantity,
                    Prices.Currency, Prices.PriceBreaks?.FirstOrDefault().Key, Prices.PriceBreaks?.FirstOrDefault().Value);
            }
            else
            {
                return String.Format("({0}){1} sku {2} - {3} on hand. ", Seller?.DisplayFlag ?? "EH?", Seller?.Name ?? "unknown", Sku, InStockQuantity);
            }
        }
    }

    public enum PartOfferPackaging
    {
        Ammo,           // "Ammo"	Continuous strip of cut tape
        AmmoPack,       // "Ammo Pack"	
        Bag,            // "Bag"	
        Box,                // "Box"	
        Bulk,                // "Bulk"	Individual components packaged in a bag
        CutTape,                // "Cut Tape"	On a tape cut off from a reel
        CustomReel,                // "Custom Reel"	Custom quantity tape in reel format
        Kit,                // "Kit	
        Magazine,                // "Magazine"	
        Rail,                // "Rail"	
        TapeAndBox,                // "Tape & Box"	
        TapeAndReel,                // "Tape & Reel"	On a tape wound around a reel directly from manufacturer
        TapeAndReel7in,                // "Tape & Reel (7 in.)"	Standard reel with 7 inch diameter
        TapeAndReel13in,                // "Tape & Reel (13 in.)"	Standard reel with 13 inch diameter
        Tray,                // "Tray"	Physically separated on a tray
        Tube,                // "Tube"	Line of components in plastic tube
        Spool,                // "Spool"	
        Strip,                // "Strip"	
        Waffle,                // "Waffle"
        Unknown // default when json converter can't figure it out
    }

}