using IdekuDoku.Domain.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace IdekuDoku.Domain.Mongo.Entities;

public class MongoContext : IMongoContext
{
    private readonly IMongoDatabase _db;

    public MongoContext(IOptions<ConnectionSetting> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        _db = client.GetDatabase(options.Value.Database);
    }

    public IMongoCollection<WebhookLog> WebhookLogs => _db.GetCollection<WebhookLog>("WebhookLogs");
}