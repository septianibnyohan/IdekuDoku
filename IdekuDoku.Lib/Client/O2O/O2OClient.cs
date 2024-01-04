using System.Text.Json;
using IdekuDoku.Lib.Constant;
using IdekuDoku.Lib.Helper;
using IdekuDoku.Lib.Settings;
using IdekuDoku.Models.Dto.O2O.Request;

namespace IdekuDoku.Lib.Client.O2O;

public class O2OClient
{
    private readonly IDokuSettings _dokuSettings;
    
    public O2OClient(IDokuSettings dokuSettings)
    {
        this._dokuSettings = dokuSettings;
    }
    
    public async Task<HttpResponseMessage> RequestO2OAsync(PaymentCodeRequestDto paymentRequestDto, string path)
    {
        DateTime currentDate = DateTime.UtcNow;
    
        string requestId = Guid.NewGuid().ToString();
        string requestTimestamp = currentDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
        String requestTarget = path;
    
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