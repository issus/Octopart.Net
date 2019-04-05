using Newtonsoft.Json;
using Octopart.Net.Schemas.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopart.Net.Converters
{
    public class PackagingConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(string));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
                return PartOfferPackaging.Unknown;

            string val = (string)reader.Value;

            if (val == "Cut Tape")
                return PartOfferPackaging.CutTape;
            if (val == "Tape & Reel")
                return PartOfferPackaging.TapeAndReel;
            if (val == "Tray")
                return PartOfferPackaging.Tray;
            if (val == "Waffle")
                return PartOfferPackaging.Waffle;
            if (val == "Tube")
                return PartOfferPackaging.Tray;
            if (val == "Bag")
                return PartOfferPackaging.Bag;
            if (val == "Bulk")
                return PartOfferPackaging.Bulk;
            if (val == "Spool")
                return PartOfferPackaging.Spool;
            if (val == "Ammo")
                return PartOfferPackaging.Ammo;
            if (val == "Ammo Pack")
                return PartOfferPackaging.AmmoPack;
            if (val == "Box")
                return PartOfferPackaging.Box;
            if (val == "Custom Reel")
                return PartOfferPackaging.CustomReel;
            if (val == "Kit")
                return PartOfferPackaging.Kit;
            if (val == "Magazine")
                return PartOfferPackaging.Magazine;
            if (val == "Rail")
                return PartOfferPackaging.Rail;
            if (val == "Tape & Box")
                return PartOfferPackaging.TapeAndBox;
            if (val == "Tape & Reel (7 in.)")
                return PartOfferPackaging.TapeAndReel7in;
            if (val == "Tape & Reel (13 in.)")
                return PartOfferPackaging.TapeAndReel13in;
            if (val == "Spool")
                return PartOfferPackaging.Spool;
            if (val == "Strip")
                return PartOfferPackaging.Strip;

            return PartOfferPackaging.Unknown;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }


        public override bool CanRead => true;

        public override bool CanWrite => false;
    }

    public class ComplianceSubTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(string));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            while (reader.TokenType != JsonToken.String)
            {
                reader.Read();
            }
            ComplianceSubType ret;

            string val = (string)reader.Value;

            if (val == "rohs_statement")
                ret = ComplianceSubType.RohsStatement;
            else if (val == "reach_statement")
                ret = ComplianceSubType.ReachStatement;
            else if (val == "materials_sheet")
                ret = ComplianceSubType.MaterialsSheet;
            else if (val == "conflict_mineral_statement")
                ret = ComplianceSubType.ConflictMineralStatement;
            else
            {
                // todo: i really dislike duplicating code...
                while (reader.TokenType != JsonToken.EndArray)
                {
                    reader.Read();
                }

                return null;
            }

            while (reader.TokenType != JsonToken.EndArray)
            {
                reader.Read();
            }

            return ret;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }


        public override bool CanRead => true;

        public override bool CanWrite => false;
    }
}
