using System.Text;
using IdekuDoku.Models.Dto.Va.Notify.Request;
using IdekuDoku.Models.Dto.Va.Notify.Response;
using IdekuDoku.Domain.Repositories;
using IdekuDoku.Models.Dto;
using IdekuDoku.Models.Dto.Va;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace IdekuDoku.Api.Services.Va;

public class NotificationServices
{
    //private readonly ITransactionRepository _transactionRepository;
    //private readonly TransactionServices _transactionServices;
    //private readonly SetupConfigurationVaServices _setupConfigurationServices;
    //private readonly AppSettings _appSettings;
    
    private readonly string? _targetPath;
    private readonly string? _sharedKey;
    private readonly ILogger<NotificationServices> _logger;

    // public NotificationServices(ITransactionRepository transactionRepository, TransactionServices transactionServices, SetupConfigurationVaServices setupConfigurationServices, IOptions<AppSettings> appSettings, ILogger<NotificationServices> logger)
    public NotificationServices(IOptions<AppSettings> appSettings, ILogger<NotificationServices> logger)
    {
        //this._transactionRepository = transactionRepository;
        //this._transactionServices = transactionServices;
        //this._setupConfigurationServices = setupConfigurationServices;
        
        //_appSettings = appSettings.Value;
        
        this._targetPath = appSettings.Value.TargetPath;
        this._sharedKey = appSettings.Value.SharedKey;
        
        _logger = logger;
    }

    public IActionResult Notify(NotifyRequestBody notifyRequestBody, NotifyRequestHeader notifyRequestHeader, string rawBody)
    {
        _logger.LogInformation("notify Request : " + notifyRequestBody);
        var notifyResponseBody = new NotifyResponseBody
        {
            Order = new IdekuDoku.Models.Dto.Va.Notify.Response.OrderResponseDto
            {
                Amount = notifyRequestBody.Order.Amount,
                InvoiceNumber = notifyRequestBody.Order.InvoiceNumber
            },
            VirtualAccountInfo = new VirtualAccountInfoResponseDto
            {
                VirtualAccountNumber = notifyRequestBody.VirtualAccountInfo == null ? null : notifyRequestBody.VirtualAccountInfo.VirtualAccountNumber
            }
        };

        string signatureGenerated;
        try
        {
            signatureGenerated = GenerateSignature(notifyRequestHeader, rawBody);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error generating signature: {ex.Message}");
            return new BadRequestObjectResult(notifyResponseBody);
        }

        if (notifyRequestHeader.Signature != signatureGenerated)
        {
            _logger.LogInformation("==== Signature Not match ====");
            _logger.LogInformation($"signature from Doku {notifyRequestHeader.Signature}");
            _logger.LogInformation($"Signature generated {signatureGenerated}");
            return new BadRequestObjectResult(notifyResponseBody);
        }

        return new OkObjectResult(notifyResponseBody);
    }

    private string GenerateSignature(NotifyRequestHeader notifyRequestHeader, string rawBody)
    {
        var signatureComponentDto = new SignatureComponentDTO
        {
            ClientId = notifyRequestHeader.ClientId,
            RequestId = notifyRequestHeader.RequestId,
            Timestamp = notifyRequestHeader.RequestTimeStamp,
            //RequestTarget = _targetPath,
            RequestTarget = "/api/Notification",
            // SecretKey = _sharedKey,
            SecretKey = "SK-DySFxwr02BttaLTz2yg6",
            MessageBody = rawBody
        };

        return GenerateSignature(signatureComponentDto);
    }

    private string GenerateSignature(SignatureComponentDTO componentDto)
    {
        var component = new StringBuilder();
        component.Append(Constants.CLIENT_ID).Append(Constants.COLON_SYMBOL).Append(componentDto.ClientId).Append(Constants.NEW_LINE);
        component.Append(Constants.REQUEST_ID).Append(Constants.COLON_SYMBOL).Append(componentDto.RequestId).Append(Constants.NEW_LINE);
        component.Append(Constants.REQUEST_TIMESTAMP).Append(Constants.COLON_SYMBOL).Append(componentDto.Timestamp).Append(Constants.NEW_LINE);
        component.Append(Constants.REQUEST_TARGET).Append(Constants.COLON_SYMBOL).Append(componentDto.RequestTarget).Append(Constants.NEW_LINE);
        var digest = HashTool.Sha256Base64(componentDto.MessageBody);
        component.Append(Constants.DIGEST).Append(Constants.COLON_SYMBOL).Append(digest);

        _logger.LogInformation("Expected Component Signature: \n{0}", component.ToString());

        var hashResult = HashTool.HmacSha256(component.ToString(), componentDto.SecretKey);
        var signature = new StringBuilder();
        signature.Append("HMACSHA256").Append(Constants.EQUALS_SIGN_SYMBOL).Append(hashResult);
        _logger.LogInformation("nilai signature : {0}", signature.ToString());
        return signature.ToString();
    }
}