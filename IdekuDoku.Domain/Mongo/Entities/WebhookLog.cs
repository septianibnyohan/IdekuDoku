using MongoDB.Bson;

namespace IdekuDoku.Domain.Mongo.Entities;

public class WebhookLog
{
    public ObjectId Id { get; set; }
    public string EventName { get; set; }
    public string Payload { get; set; }
    public DateTime ReceivedAt { get; set; }
}