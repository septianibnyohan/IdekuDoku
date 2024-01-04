using IdekuDoku.Domain.Mongo.Entities;
using MongoDB.Driver;

namespace IdekuDoku.Domain.Mongo.Repositories;

public class WebhookLogRepo : IWebhookLogRepo
{

    private readonly IMongoContext _mongoContext;

    public WebhookLogRepo(IMongoContext mongoContext)
    {
        _mongoContext = mongoContext;
    }
    
    public async Task<IEnumerable<WebhookLog>> GetAllWebhook()
    {
        try
        {
            return await _mongoContext.WebhookLogs
                .Find(_ => true).ToListAsync();
        }
        catch (Exception ex)
        {
            // log or manage the exception
            throw ex;
        }
    }

    public async Task<IEnumerable<WebhookLog>> GetLogsByEventNameAsync(string eventName)
    {
        try
        {
            var query = _mongoContext.WebhookLogs.Find(webhooklog => 
                webhooklog.EventName.Contains(eventName));

            return await query.ToListAsync();
        }
        catch (Exception ex)
        {
            // log or manage the exception
            throw ex;
        }
    }

    public async Task Create(WebhookLog webhookLog)
    {
        try
        {
            await _mongoContext.WebhookLogs.InsertOneAsync(webhookLog);
        }
        catch (Exception ex)
        {
            // log or manage the exception
            throw ex;
        }
    }
}