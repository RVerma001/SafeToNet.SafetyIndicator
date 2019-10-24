using System;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using SafeToNet.SafetyIndicator.Core.Models.Constants;

namespace SafeToNet.SafetyIndicator.Core.Models.Entities
{
    public class AuthCredentials
    {
        [BsonId]
        [JsonProperty(AnnotationConsts.Id)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [JsonProperty(AnnotationConsts.AccessCode)]
        [BsonElement(AnnotationConsts.AccessCode)]
        public string Code { get; set; }

        [JsonProperty(AnnotationConsts.DeviceId)]
        [BsonElement(AnnotationConsts.DeviceId)]
        public Guid DeviceId { get; set; }

        [JsonProperty(AnnotationConsts.AccessToken)]
        [BsonElement(AnnotationConsts.AccessToken)]
        public AccessToken AccessToken { get; set; }

        [JsonProperty(AnnotationConsts.RefreshTokens)]
        [BsonElement(AnnotationConsts.RefreshTokens)]
        public RefreshToken RefreshToken { get; set; }

        public bool HasValidRefreshToken(string refreshToken)
        {
            return ((RefreshToken != null) && RefreshToken.Token == refreshToken && RefreshToken.Active);
        }

        public void SetRefreshToken(string token, Guid? deviceId, double daysToExpire = 2)
        {
            this.RefreshToken = new RefreshToken(token, DateTime.UtcNow.AddDays(daysToExpire), deviceId);
        }
    }
}
