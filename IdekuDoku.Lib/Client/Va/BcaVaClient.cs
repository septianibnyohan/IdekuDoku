using IdekuDoku.Lib.Constant;
using IdekuDoku.Lib.Pojo;
using IdekuDoku.Models.Dto.Va.Payment.Request;

namespace IdekuDoku.Lib.Client.Va;

public class BcaVaClient
{
  private readonly RequestVaClient _requestVaClient;
  
  public BcaVaClient(RequestVaClient requestVaClient)
  {
    this._requestVaClient = requestVaClient;
  }

  public async Task<HttpResponseMessage> GenerateBcaVa(SetupConfiguration setupConfiguration, PaymentRequestDto paymentRequestDto)
  {
    string path = "/bca-virtual-account/v2/payment-code";
    return await _requestVaClient.RequestVaAsync(setupConfiguration, paymentRequestDto, path);
  }
  
  public async Task<HttpResponseMessage> GenerateBcaVaBeta(SetupConfiguration setupConfiguration, VaPaymentCodeRequestDto paymentRequestDto)
  {
    string path = DokuUrl.BCA_VA_GENERATE_PAYMENT_CODE;
    return await _requestVaClient.RequestVaAsyncVAlpha(setupConfiguration, paymentRequestDto, path);
  }
}