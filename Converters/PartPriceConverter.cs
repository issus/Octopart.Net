using Newtonsoft.Json;
using Octopart.Net.Schemas.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Octopart.Net.Converters
{
    public class PartPriceConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Price));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var price = new Price();

            if (reader.TokenType == JsonToken.StartObject)
                reader.Read();

            if (reader.TokenType == JsonToken.EndObject)
                return null;

            if (reader.ValueType == typeof(string))
                price.Currency = (string)reader.Value;

            reader.Read();
            if (reader.TokenType == JsonToken.StartArray)
                reader.Read();

            while (reader.TokenType == JsonToken.StartArray)
            {
                int? k = reader.ReadAsInt32();
                decimal? v = reader.ReadAsDecimal();

                if (k != null && v != null)
                {
                    price.PriceBreaks.Add(k.Value, v.Value);
                }

                reader.Read();reader.Read();
            }

            while (reader.TokenType != JsonToken.EndObject)
                reader.Read();

            return price;

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanRead => true;

        public override bool CanWrite => false;
    }
}
