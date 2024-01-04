using IdekuDoku.Models.Dto.O2O.Request;

namespace IdekuDoku.Lib.Client.O2O;

public class IndomaretClient
{
    private readonly O2OClient _requestO2OClient;
  
    public IndomaretClient(O2OClient requestO2OClient)
    {
        this._requestO2OClient = requestO2OClient;
    }
    
    public async Task<HttpResponseMessage> GenerateAlfaO2O(PaymentCodeRequestDto paymentRequestDto)
    {
        string path = "/indomaret-online-to-offline/v2/payment-code";

        return await _requestO2OClient.RequestO2OAsync(paymentRequestDto, path);
    }
}