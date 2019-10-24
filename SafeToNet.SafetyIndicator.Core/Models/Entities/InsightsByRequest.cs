using System;
using Newtonsoft.Json;
using SafeToNet.SafetyIndicator.Core.Models.Constants;

namespace SafeToNet.SafetyIndicator.Core.Models.Entities
{
    public class InsightsByRequest
    {
        [JsonProperty(StrikeConstants.DeviceId)]
        public Guid DeviceId { get; set; }
        [JsonProperty(StrikeConstants.Hours)]
        public double Hours { get; set; }
        [JsonProperty(StrikeConstants.Minutes)]
        public int Minutes { get; set; }
    }
}
