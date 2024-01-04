using MongoDB.Driver;

namespace IdekuDoku.Domain.Mongo.Entities;

public interface IMongoContext
{
    IMongoCollection<WebhookLog> WebhookLogs { get; }
}