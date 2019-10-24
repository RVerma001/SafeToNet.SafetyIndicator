using System;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using SafeToNet.SafetyIndicator.Core.Models.Constants;

namespace SafeToNet.SafetyIndicator.Core.Deserialisers
{
    public class BsonStringDateTimeSerialiser : SerializerBase<DateTime>
    {
        public override DateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            while (context.Reader.State != BsonReaderState.Type ||
                    context.Reader.ReadBsonType() != BsonType.EndOfDocument)
            {
                var type = context.Reader.GetCurrentBsonType();

                switch (type)
                {
                    case BsonType.String:
                        return DateTime.Parse(context.Reader.ReadString());
                    case BsonType.DateTime:
                        return Convert.ToDateTime(context.Reader.ReadDateTime());
                    default:
                        return DateTime.MinValue;
                }
            }

            return DateTime.MinValue;
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateTime value)
        {
            while (context.Writer.State != BsonWriterState.Name)
                context.Writer.WriteString(value.ToString(StrikeConstants.UTCDateTimeFormat));
        }

    }
}