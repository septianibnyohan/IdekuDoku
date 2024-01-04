using System.Text;
using System.Text.Json;
using IdekuDoku.Lib.Builder;
using IdekuDoku.Lib.Constant;
using IdekuDoku.Lib.Helper;
using IdekuDoku.Lib.Pojo;
using IdekuDoku.Lib.Settings;
using IdekuDoku.Models.Dto.Va.Payment.Request;
using Microsoft.Extensions.Logging;

namespace IdekuDoku.Lib.Client.Va;

public class RequestVaClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger<RequestVaClient> _logger;
  private readonly IDokuSettings _dokuSettings;

  /*
  public RequestVaClient()
  {
    this._httpClient = new HttpClient();
    //this.logger = new Logger<RequestVaClient>();
  }
  */
  
  public RequestVaClient(HttpClient httpClient, ILogger<RequestVaClient> logger, IDokuSettings dokuSettings)
  {
    this._httpClient = httpClient;
    this._logger = logger;
    this._dokuSettings = dokuSettings;
  }

  public async Task<HttpResponseMessage> RequestVaAsync(SetupConfiguration setupConfiguration, PaymentRequestDto paymentRequestDto, string path)
  {
    var jsonSerializerOptions = new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      WriteIndented = true, // Optional: to format JSON for better readability
    };

    var clientSetup = new ClientSetup();
    var setup = await clientSetup.SetupRequestAsync(setupConfiguration, paymentRequestDto, path);

    _logger.LogInformation("===REQUEST====");
    _logger.LogInformation($"REQUEST URL : {setupConfiguration.ServerLocation}{path}");
    _logger.LogInformation($"REQUEST HEADER : {JsonSerializer.Serialize(setup.Headers, jsonSerializerOptions)}");
    _logger.LogInformation($"REQUEST BODY : {await setup.ReadAsStringAsync()}");

    var response = await _httpClient.PostAsync($"{setupConfiguration.ServerLocation}{path}", setup);

    _logger.LogInformation("===RESPONSE====");
    _logger.LogInformation($"RESPONSE STATUS CODE: {response.StatusCode}");
    _logger.LogInformation($"RESPONSE CONTENT: {await response.Content.ReadAsStringAsync()}");

    return response;
  }
  
  public async Task<HttpResponseMessage> RequestVaAsyncRequestVaAsyncVAlphaVBeta(SetupConfiguration setupConfiguration, 
    VaPaymentCodeRequestDto paymentRequestDto, string path)
  {
    DateTime currentDate = DateTime.UtcNow;
    
    string? requestId = Guid.NewGuid().ToString();
    string? requestTimestamp = currentDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
    string requestTarget = path;
    
    JsonSerializerOptions options = new JsonSerializerOptions
    {
      DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    string bodyContent = JsonSerializer.Serialize(paymentRequestDto, options);
    
    var digest = DokuCrypt.GenerateDigest(bodyContent);
    var signature = DokuCrypt.GenerateSignature(_dokuSettings.ClientId, requestId, requestTimestamp, requestTarget, digest, _dokuSettings.ClientSecret);
    
    String url = DokuUrl.BaseUrl + requestTarget;
    
    var headers = new Dictionary<string, string?>();
    headers.Add(DokuCrypt.CLIENT_ID, _dokuSettings.ClientId);
    headers.Add(DokuCrypt.REQUEST_ID, requestId);
    headers.Add(DokuCrypt.REQUEST_TIMESTAMP, requestTimestamp);
    headers.Add(DokuCrypt.SIGNATURE, signature);
      
    var client = new HttpClient();
    var request = new HttpRequestMessage(HttpMethod.Post, url);
    
    foreach (var header in headers)
    {
      request.Headers.Add(header.Key, header.Value);
    }
    
    var content = new StringContent(bodyContent, Encoding.UTF8, "application/json");
    request.Content = content;
    var response = await client.SendAsync(request);

    return response;
  }
  
  public async Task<HttpResponseMessage> RequestVaAsyncVAlpha(SetupConfiguration setupConfiguration, 
    VaPaymentCodeRequestDto paymentRequestDto, string path)
  {
    DateTime currentDate = DateTime.UtcNow;
    
    string requestId = Guid.NewGuid().ToString();
    string requestTimestamp = currentDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
    String requestTarget = DokuUrl.BCA_VA_GENERATE_PAYMENT_CODE;
    
    JsonSerializerOptions options = new JsonSerializerOptions
    {
      DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    string bodyContent = JsonSerializer.Serialize(paymentRequestDto, options);
    
    var digest = DokuCrypt.GenerateDigest(bodyContent);
    var signature = DokuCrypt.GenerateSignature(_dokuSettings.ClientId, requestId, requestTimestamp, requestTarget, digest, _dokuSettings.ClientSecret);
    
    var client = new HttpClient();
    var request = new HttpRequestMessage(HttpMethod.Post, DokuUrl.BaseUrl + DokuUrl.BCA_VA_GENERATE_PAYMENT_CODE);
    request.Headers.Add("Client-Id", _dokuSettings.ClientId);
    request.Headers.Add("Request-Id", requestId);
    request.Headers.Add("Request-Timestamp", requestTimestamp);
    request.Headers.Add("Signature", signature);
    
    var content = new StringContent(bodyContent, null, "application/json");
    request.Content = content;
    
    var response = await client.SendAsync(request);
    response.EnsureSuccessStatusCode();
    
    Console.WriteLine(await response.Content.ReadAsStringAsync());

    return response;
  }
}