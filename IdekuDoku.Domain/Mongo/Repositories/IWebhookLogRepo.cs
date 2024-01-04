using IdekuDoku.Domain.Mongo.Entities;

namespace IdekuDoku.Domain.Mongo.Repositories;

public interface IWebhookLogRepo
{
    Task<IEnumerable<WebhookLog>> GetAllWebhook();

    Task<IEnumerable<WebhookLog>> GetLogsByEventNameAsync(string eventName);

    Task Create(WebhookLog webhookLog);
}