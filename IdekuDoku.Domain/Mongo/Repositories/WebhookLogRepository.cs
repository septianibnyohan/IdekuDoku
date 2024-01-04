using IdekuDoku.Domain.Mongo.Entities;
using MongoDB.Driver;

namespace IdekuDoku.Domain.Mongo.Repositories;

public class WebhookLogRepository : GenericRepository<WebhookLog>, IWebhookLogRepository
{
    public WebhookLogRepository(IMongoDatabase database) : base(database, "WebhookLogs")
    {
        // Additional initialization if needed
    }

    // You can implement additional methods specific to WebhookLog if needed
    public async Task<List<WebhookLog>> GetLogsByEventNameAsync(string eventName)
    {
        var filter = Builders<WebhookLog>.Filter.Eq(log => log.EventName, eventName);
        return await FindAsync(filter);
    }
    
    // Override the base FindAsync method to handle FilterDefinition
    private async Task<List<WebhookLog>> FindAsync(FilterDefinition<WebhookLog> filter)
    {
        return await _collection.Find(filter).ToListAsync();
    }
}