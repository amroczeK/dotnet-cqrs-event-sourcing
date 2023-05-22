using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CQRS.Core.Events
{
    /// <summary>
    /// Event Store schema, each instance of the event model represents a record in the event store.
    /// We are using MongoDB as the event store, so each instance will represent a Document in the event store collection. 
    /// Each document will represent an event that is versioned, that can alter the state of the aggregate.
    /// </summary>
    public class EventModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public DateTime TimeStamp { get; set; }
        public Guid AggregateIdentifier { get; set; }
        public string AggregateType { get; set; } = string.Empty;
        public int Version { get; set; }
        public string EventType { get; set; } = string.Empty;
        public BaseEvent? EventData { get; set; }
    }
}