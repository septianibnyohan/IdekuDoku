using IdekuDoku.Lib.Constant;
using Newtonsoft.Json;

namespace IdekuDoku.Lib.Helper;

public class DokuApiBase
{
    private static Dictionary<string, string?> GetHeaders(string? clientId, string? requestId, string? requestTimestamp, string? signature)
    {
        var headers = new Dictionary<string, string?>();
        headers.Add(DokuCrypt.CLIENT_ID, clientId);
        headers.Add(DokuCrypt.REQUEST_ID, requestId);
        headers.Add(DokuCrypt.REQUEST_TIMESTAMP, requestTimestamp);
        headers.Add(DokuCrypt.SIGNATURE, signature);

        return headers;
    }
    public static async Task<string> DoCheckoutInitiatePayment(string? clientId, string? requestId, string? requestTimestamp, string? signature, string bodyJson)
    {
        String curl = DokuUrl.BaseUrl + DokuUrl.CHECKOUT_INITIATE_PAYMENT;
        
        var headers = GetHeaders(clientId, requestId, requestTimestamp, signature);
        string header = JsonConvert.SerializeObject(headers);

        var res = await HttpRequest.Curl(DokuUrl.BaseUrl + DokuUrl.CHECKOUT_INITIATE_PAYMENT, headers, bodyJson);
        
        return res;
    }
    
    public static async Task<string> GenerateCcPaymentPage(string? clientId, string? requestId, string? requestTimestamp, string? signature, string bodyJson)
    {
        String curl = DokuUrl.BaseUrl + DokuUrl.CHECKOUT_INITIATE_PAYMENT;
        
        var headers = GetHeaders(clientId, requestId, requestTimestamp, signature);
        string header = JsonConvert.SerializeObject(headers);

        var res = await HttpRequest.Curl(DokuUrl.BaseUrl + DokuUrl.CC_GENERATE_PAYMENT_PAGE, headers, bodyJson);
        
        return res;
    }
}