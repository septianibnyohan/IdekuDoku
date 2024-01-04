using IdekuDoku.Domain.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace IdekuDoku.Domain.Entities;

public class MongoDBContext : IMongoDBContext
{
    private readonly IMongoDatabase _database;

    public MongoDBContext(IOptions<MongoDBSettings> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        _database = client.GetDatabase(options.Value.DatabaseName);
    }

    public IMongoDatabase Database => _database;
}