using System.Net.Mime;
using IdekuDoku.Models.Dto.Va.Notify.Request;
using IdekuDoku.Api.Services.Va;
using IdekuDoku.Domain.Mongo.Entities;
using IdekuDoku.Domain.Mongo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IdekuDoku.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
  private readonly NotificationServices _notificationServices;
  private readonly ILogger<NotificationController> _logger;

  //private readonly IUnitOfWork _unitOfWork;
  private readonly IWebhookLogRepo _webhookLogRepo;
  //private readonly IWebhookLogRepository _webhookLogRepository;

  public NotificationController(NotificationServices notificationServices, ILogger<NotificationController> logger,
    IWebhookLogRepo webhookLogRepo)
  {
    _notificationServices = notificationServices;
    _logger = logger;

    //_unitOfWork = unitOfWork;
    _webhookLogRepo = webhookLogRepo;
    //_webhookLogRepository = webhookLogRepository;
  }
  
  /*
  [HttpPost]
  [Consumes(MediaTypeNames.Application.Json)]
  [Produces(MediaTypeNames.Application.Json)]
  public async Task<IActionResult> Notify(
    [FromHeader(Name = "Client-Id")] string clientId,
    [FromHeader(Name = "Signature")] string signature,
    [FromHeader(Name = "Request-Id")] string requestId,
    [FromHeader(Name = "Request-Timestamp")] string requestTimeStamp,
    [FromBody] string bodyRequest)
  {
    try
    {
      var notifyRequestHeader = new NotifyRequestHeader
      {
        ClientId = clientId,
        RequestId = requestId,
        Signature = signature,
        RequestTimeStamp = requestTimeStamp
      };

      _logger.LogInformation("Request Value: " + bodyRequest);
      
      //_unitOfWork.BeginTransaction();

      var webhookLog = new WebhookLog
      {
        EventName = "ReceiveNotification",
        Payload = bodyRequest,
        ReceivedAt = DateTime.Now
      };

      //await _webhookLogRepository.AddAsync(webhookLog);
      //await _unitOfWork.CommitTransactionAsync();
      await _webhookLogRepo.Create(webhookLog);
      
      var notifyRequestBody = Newtonsoft.Json.JsonConvert.DeserializeObject<NotifyRequestBody>(bodyRequest);// Deserialize your JSON using a JSON library (e.g., Newtonsoft.Json)
      
      var result = _notificationServices.Notify(notifyRequestBody ?? throw new InvalidOperationException(), notifyRequestHeader, bodyRequest);

      return Ok(result);
    }
    catch (Exception ex)
    {
      _logger.LogError("Error processing notification", ex);
      //await _unitOfWork.RollbackTransactionAsync();
      return BadRequest();
    }
  }
  */
  
  [HttpPost]
  public async Task<IActionResult> Notify(
    [FromHeader(Name = "Client-Id")] string clientId,
    [FromHeader(Name = "Signature")] string signature,
    [FromHeader(Name = "Request-Id")] string requestId,
    [FromHeader(Name = "Request-Timestamp")] string requestTimeStamp,
    [FromBody] NotifyRequestBody notify)
  {
    try
    {
      var notifyRequestHeader = new NotifyRequestHeader
      {
        ClientId = clientId,
        RequestId = requestId,
        Signature = signature,
        RequestTimeStamp = requestTimeStamp
      };
      
      var bodyRequest = Newtonsoft.Json.JsonConvert.SerializeObject(notify);

      _logger.LogInformation("Request Value: " + bodyRequest);
      
      //_unitOfWork.BeginTransaction();

      var webhookLog = new WebhookLog
      {
        EventName = "ReceiveNotification",
        Payload = bodyRequest,
        ReceivedAt = DateTime.Now
      };

      //await _webhookLogRepository.AddAsync(webhookLog);
      //await _unitOfWork.CommitTransactionAsync();
      await _webhookLogRepo.Create(webhookLog);
      
      var notifyRequestBody = Newtonsoft.Json.JsonConvert.DeserializeObject<NotifyRequestBody>(bodyRequest);// Deserialize your JSON using a JSON library (e.g., Newtonsoft.Json)
      
      var result = _notificationServices.Notify(notifyRequestBody ?? throw new InvalidOperationException(), notifyRequestHeader, bodyRequest);

      return Ok(result);
    }
    catch (Exception ex)
    {
      _logger.LogError("Error processing notification", ex);
      //await _unitOfWork.RollbackTransactionAsync();
      return BadRequest();
    }
  }
}