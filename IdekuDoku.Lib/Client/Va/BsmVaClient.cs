using IdekuDoku.Lib.Constant;
using IdekuDoku.Lib.Pojo;
using IdekuDoku.Models.Dto.Va.Payment.Request;

namespace IdekuDoku.Lib.Client.Va;

public class BsmVaClient
{
  private readonly RequestVaClient _requestVaClient;
  
  public BsmVaClient(RequestVaClient requestVaClient)
  {
    this._requestVaClient = requestVaClient;
  }

  public async Task<HttpResponseMessage> GenerateBsmVa(SetupConfiguration setupConfiguration, PaymentRequestDto paymentRequestDto)
  {
    string path = "/bsm-virtual-account/v2/payment-code";
    return await _requestVaClient.RequestVaAsync(setupConfiguration, paymentRequestDto, path);
  }
  
  public async Task<HttpResponseMessage> GenerateBsmVa(SetupConfiguration setupConfiguration, VaPaymentCodeRequestDto paymentRequestDto)
  {
    string path = DokuUrl.BSI_VA_GENERATE_PAYMENT_CODE;
    return await _requestVaClient.RequestVaAsyncVAlpha(setupConfiguration, paymentRequestDto, path);
  }
}