using Newtonsoft.Json;
using SafeToNet.SafetyIndicator.Core.Deserialisers;
using SafeToNet.SafetyIndicator.Core.Models.Constants;
using System;

namespace SafeToNet.SafetyIndicator.Core.Models.Entities
{
    public class InsightGraph
    {
        [JsonProperty(StrikeConstants.Value)]
        public decimal Value { get; set; }

        [JsonProperty(StrikeConstants.DateGenerated)]
        [JsonConverter(typeof(JsonStringToDateTimeConverter))]
        public DateTime DateGenerated { get; set; }
    }
}