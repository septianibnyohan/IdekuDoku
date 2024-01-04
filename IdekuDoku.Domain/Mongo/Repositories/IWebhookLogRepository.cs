using IdekuDoku.Domain.Mongo.Entities;

namespace IdekuDoku.Domain.Mongo.Repositories;

public interface IWebhookLogRepository : IGenericRepository<WebhookLog>
{
    // You can add additional methods specific to WebhookLog if needed
    Task<List<WebhookLog>> GetLogsByEventNameAsync(string eventName);
}