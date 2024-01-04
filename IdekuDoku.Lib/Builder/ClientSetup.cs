using System.Globalization;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Xml.Schema;
using IdekuDoku.Lib.Pojo;
using IdekuDoku.Models.Dto.Va.Payment.Request;

namespace IdekuDoku.Lib.Builder;

public class ClientSetup
{
    private readonly HttpClient httpClient;

    public ClientSetup()
    {
        httpClient = new HttpClient();
    }

    /*
    public async Task<HttpResponseMessage> SetupRequestAsync(SetupConfiguration setupConfiguration, PaymentRequestDto paymentRequestDto, string path)
    {
        string? clientId = setupConfiguration.ClientId;
        string date = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture);
        string reqId = DateTime.Now.Ticks.ToString();

        JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        string jsonBodyString = JsonSerializer.Serialize(paymentRequestDto, jsonSerializerOptions);

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] digest = sha256.ComputeHash(Encoding.UTF8.GetBytes(jsonBodyString));
            string base64HmacSha256 = Convert.ToBase64String(digest);
            string signatureComponents = $"Client-Id:{clientId}\nRequest-Id:{reqId}\nRequest-Timestamp:{date}\nRequest-Target:{path}\nDigest:{base64HmacSha256}";
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(setupConfiguration.Key)))
            {
                byte[] hmacBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(signatureComponents));
                string result = Convert.ToBase64String(hmacBytes);

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, path);
                request.Content = new StringContent(jsonBodyString, Encoding.UTF8, "application/json");
                request.Headers.Add("Signature", "HMACSHA256=" + result);
                request.Headers.Add("Request-Id", reqId);
                request.Headers.Add("Client-Id", clientId);
                request.Headers.Add("Request-Timestamp", date);

                HttpResponseMessage response = await httpClient.SendAsync(request);

                return response;
            }
        }
    }
    */
    
    public async Task<StringContent> SetupRequestAsync(SetupConfiguration setupConfiguration, PaymentRequestDto paymentRequestDto, string path)
    {
        string? clientId = setupConfiguration.ClientId;
        string date = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture);
        string reqId = DateTime.Now.Ticks.ToString();

        JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        string jsonBodyString = JsonSerializer.Serialize(paymentRequestDto, jsonSerializerOptions);

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] digest = sha256.ComputeHash(Encoding.UTF8.GetBytes(jsonBodyString));
            string base64HmacSha256 = Convert.ToBase64String(digest);
            string signatureComponents = $"Client-Id:{clientId}\nRequest-Id:{reqId}\nRequest-Timestamp:{date}\nRequest-Target:{path}\nDigest:{base64HmacSha256}";
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(setupConfiguration.Key)))
            {
                byte[] hmacBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(signatureComponents));
                string result = Convert.ToBase64String(hmacBytes);

                // Assuming HttpHeaders is a class that allows you to set headers
                HttpHeaders httpHeaders = new HttpHeaders();
                
                // Set headers as needed
                //httpHeaders.Add("Content-Type", "application/json");
                httpHeaders.Add("Signature", "HMACSHA256=" + result);
                httpHeaders.Add("Request-Id", reqId);
                httpHeaders.Add("Client-Id", clientId);
                httpHeaders.Add("Request-Timestamp", date);
                
                // Create StringContent with the JSON payload
                StringContent content = new StringContent(jsonBodyString, Encoding.UTF8, "application/json");
                
                foreach (var header in httpHeaders)
                {
                    content.Headers.Add(header.Key, header.Value);
                }

                return content;
            }
        }
    }
}