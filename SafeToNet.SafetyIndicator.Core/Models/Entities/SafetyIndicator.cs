using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using SafeToNet.SafetyIndicator.Core.Deserialisers;
using SafeToNet.SafetyIndicator.Core.Models.Constants;

namespace SafeToNet.SafetyIndicator.Core.Models.Entities
{
    public class SafetyIndicator : IEntity
    {
        [BsonElement(StrikeConstants.DeviceId)]
        [JsonProperty(StrikeConstants.DeviceId)]
        public Guid DeviceId { get; set; }

        [JsonProperty(StrikeConstants.ProtectionLevel)]
        [BsonElement(StrikeConstants.ProtectionLevel)]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal ProtectionLevel { get; set; }

        [BsonElement(StrikeConstants.DateGenerated)]
        [BsonSerializer(typeof(BsonStringDateTimeSerialiser))]
        [JsonProperty(StrikeConstants.DateGenerated)]
        [JsonConverter(typeof(JsonStringToDateTimeConverter))]
        public DateTime DateGenerated { get; set; }

        [BsonId]
        [JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}