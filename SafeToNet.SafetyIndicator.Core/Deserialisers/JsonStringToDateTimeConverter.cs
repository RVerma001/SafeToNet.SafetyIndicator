using System;
using Newtonsoft.Json;
using SafeToNet.SafetyIndicator.Core.Models.Constants;

namespace SafeToNet.SafetyIndicator.Core.Deserialisers
{
    public class JsonStringToDateTimeConverter : JsonConverter<DateTime>
    {
        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString(StrikeConstants.UTCDateTimeFormat));
        }

        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return reader.TokenType == JsonToken.Date
                    ? Convert.ToDateTime(reader.Value).ToUniversalTime()
                    : DateTime.Parse(reader.Value.ToString()).ToUniversalTime();
        }
    }
}
