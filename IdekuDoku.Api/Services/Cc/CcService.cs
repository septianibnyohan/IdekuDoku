using System.Text;
using System.Text.Json;
using IdekuDoku.Lib.Constant;
using IdekuDoku.Lib.Helper;
using IdekuDoku.Lib.Pojo;
using IdekuDoku.Lib.Settings;
using IdekuDoku.Models.Dto.Cc.Request;
using IdekuDoku.Models.Dto.Cc.Response;
using IdekuDoku.Models.Dto.Jokul.Response;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace IdekuDoku.Api.Services.Cc;

public class CcService
{
  private readonly IDokuSettings _dokuSettings;

  public CcService(IDokuSettings dokuSettings)
  {
    _dokuSettings = dokuSettings;
  }
  
  public async Task<PaymentTokenResponseDto?> GenerateToken(SetupConfiguration setupConfiguration, PaymentTokenRequestDto paymentRequestDto)
  {
    var httpClient = new HttpClient();
    httpClient.BaseAddress = new Uri(setupConfiguration.Environment);
    httpClient.Timeout = TimeSpan.FromSeconds(120);

    // var jsonPaymentRequestDto = JsonSerializer.Serialize(paymentRequestDto);
    var jsonPaymentRequestDto =
      "{ \n    \"order\": {\n       \t\"invoice_number\":\"INV-1703229268\",\n       \t\"line_items\": [\n\t\t\t{\n      \t\t\"name\": \"DOKU T-Shirt Merah\",\n      \t\t\"price\": 30000,\n      \t\t\"quantity\": 2\n    \t\t},\n\t\t\t{\n      \t\t\"name\": \"DOKU T-Shirt Biru\",\n      \t\t\"price\": 30000,\n      \t\t\"quantity\": 1\n    \t\t}\n  \t\t],\n       \t\"amount\": 90000,\n       \t\"callback_url\": \"https://doku.com\",\n       \t\"auto_redirect\": false,\n       \t\"session_id\": \"0000231223\"\n    },\n    \"customer\": {\n    \t\"id\":\"W7rbKhPYh76VSHYwHRaGDIbBhgTebgAoWtX\",\n    \t\"name\":\"Anton Budiman\",\n    \t\"email\":\"anton@doku.com\",\n    \t\"phone\":\"+6281287458232\",\n\t\t\"address\":\"Jakarta, Menara Mulia Lt 8\",\n\t\t\"country\":\"ID\"\n\t},\n    \"override_configuration\": {\n        \"themes\": {\n            \"language\": \"ID\",\n            \"background_color\": \"\",\n            \"font_color\": \"\",\n            \"button_background_color\": \"\",\n            \"button_font_color\": \"\"\n        }\n    }\n}";
    
    var requestContent = new StringContent(jsonPaymentRequestDto, Encoding.UTF8, "application/json");

    // var response = await httpClient.PostAsync("wt-redirect-services/token", requestContent);
    var response = await httpClient.PostAsync("credit-card/v1/payment-page", requestContent);

    if (response.IsSuccessStatusCode)
    {
      var responseContent = await response.Content.ReadAsStringAsync();
      return JsonSerializer.Deserialize<PaymentTokenResponseDto>(responseContent, new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true // Make property names case-insensitive
      });
    }
    else
    {
      // Handle the error
      throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
    }
  }
  
  public async Task<PaymentTokenResponseDto?> GenerateTokenVBeta(SetupConfiguration setupConfiguration, CcGeneratePaymentRequestDto paymentRequestDto)
  {
    // Get Signature
    DateTime currentDate = DateTime.UtcNow;
    
    string? requestId = Guid.NewGuid().ToString();
    string? requestTimestamp = currentDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
    const string requestTarget = DokuUrl.CC_GENERATE_PAYMENT_PAGE;
    
    JsonSerializerOptions options = new JsonSerializerOptions
    {
      DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    string jsonString = JsonSerializer.Serialize(paymentRequestDto, options);
    
    var digest = DokuCrypt.GenerateDigest(jsonString);
    var signature = DokuCrypt.GenerateSignature(_dokuSettings.ClientId, requestId, requestTimestamp, requestTarget, digest, _dokuSettings.ClientSecret);
    
    var res = await DokuApiBase.GenerateCcPaymentPage(_dokuSettings.ClientId, requestId, requestTimestamp, signature, jsonString);
    var objResp = JsonConvert.DeserializeObject<PaymentTokenResponseDto>(res);

    return objResp;
    
    var client = new HttpClient();
    var request = new HttpRequestMessage(HttpMethod.Post, "https://api-sandbox.doku.com/credit-card/v1/payment-page");
    request.Headers.Add("Client-Id", "BRN-0206-1696237638820");
    request.Headers.Add("Request-Id", "93626957-8ebe-4e0e-9778-3a1a623ea18b");
    request.Headers.Add("Request-Timestamp", "2020-12-23T06:51:24Z");
    request.Headers.Add("Signature", "EPw8LpnEN9MMKgNg+PDpufYAsnK7cEGxJuK9iiMiYrw=");
    var content = new StringContent("{ \n    \"order\": {\n       \t\"invoice_number\":\"INV-1703229430\",\n       \t\"line_items\": [\n\t\t\t{\n      \t\t\"name\": \"DOKU T-Shirt Merah\",\n      \t\t\"price\": 30000,\n      \t\t\"quantity\": 2\n    \t\t},\n\t\t\t{\n      \t\t\"name\": \"DOKU T-Shirt Biru\",\n      \t\t\"price\": 30000,\n      \t\t\"quantity\": 1\n    \t\t}\n  \t\t],\n       \t\"amount\": 90000,\n       \t\"callback_url\": \"https://doku.com\",\n       \t\"auto_redirect\": false,\n       \t\"session_id\": \"0000231223\"\n    },\n    \"customer\": {\n    \t\"id\":\"W7rbKhPYh76VSHYwHRaGDIbBhgTebgAoWtX\",\n    \t\"name\":\"Anton Budiman\",\n    \t\"email\":\"anton@doku.com\",\n    \t\"phone\":\"+6281287458232\",\n\t\t\"address\":\"Jakarta, Menara Mulia Lt 8\",\n\t\t\"country\":\"ID\"\n\t},\n    \"override_configuration\": {\n        \"themes\": {\n            \"language\": \"ID\",\n            \"background_color\": \"\",\n            \"font_color\": \"\",\n            \"button_background_color\": \"\",\n            \"button_font_color\": \"\"\n        }\n    }\n}", null, "application/json");
    request.Content = content;
    var response = await client.SendAsync(request);
    response.EnsureSuccessStatusCode();
    Console.WriteLine(await response.Content.ReadAsStringAsync());
    
    if (response.IsSuccessStatusCode)
    {
      var responseContent = await response.Content.ReadAsStringAsync();
      return JsonSerializer.Deserialize<PaymentTokenResponseDto>(responseContent, new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true // Make property names case-insensitive
      });
    }
    else
    {
      // Handle the error
      throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
    }

  }
}