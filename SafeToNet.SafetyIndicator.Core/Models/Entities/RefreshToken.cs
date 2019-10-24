using System;
using MongoDB.Bson.Serialization.Attributes;
using SafeToNet.SafetyIndicator.Core.Models.Constants;

namespace SafeToNet.SafetyIndicator.Core.Models.Entities
{
    public class RefreshToken
    {
        [BsonElement(AnnotationConsts.AccessToken)]
        public string Token { get; }
        [BsonElement(AnnotationConsts.Expires)]
        public DateTime Expires { get; private set; }
        [BsonElement(AnnotationConsts.DeviceId)]
        public Guid? DeviceId { get; }
        [BsonElement(AnnotationConsts.Active)]
        public bool Active => DateTime.UtcNow <= Expires;
        [BsonElement(AnnotationConsts.DateGenerated)]
        public DateTime DateGenerated { get; set; } = DateTime.UtcNow;
        [BsonElement(AnnotationConsts.DateModified)]
        public DateTime DateModified { get; set; } = DateTime.UtcNow;
        [BsonElement(AnnotationConsts.Id)]
        public Guid Id { get; set; } = Guid.NewGuid();

        public RefreshToken(string token, DateTime expires, Guid? deviceId)
        {
            Token = token;
            Expires = expires;
            DeviceId = deviceId;
        }
    }
}
