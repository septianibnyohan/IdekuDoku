using IdekuDoku.Lib.Constant;
using IdekuDoku.Lib.Pojo;
using IdekuDoku.Models.Dto.Va.Payment.Request;

namespace IdekuDoku.Lib.Client.Va;

public class DokuVaClient
{
  private readonly RequestVaClient _requestVaClient;

  public DokuVaClient(RequestVaClient requestVaClient)
  {
    this._requestVaClient = requestVaClient;
  }

  public async Task<HttpResponseMessage> GenerateDokuVa(SetupConfiguration setupConfiguration, PaymentRequestDto paymentRequestDto)
  {
    string path = "/doku-virtual-account/v2/payment-code";
    return await _requestVaClient.RequestVaAsync(setupConfiguration, paymentRequestDto, path);
  }
  
  public async Task<HttpResponseMessage> GenerateDokuVa(SetupConfiguration setupConfiguration, VaPaymentCodeRequestDto paymentRequestDto)
  {
    string path = DokuUrl.DOKU_VA_GENERATE_PAYMENT_CODE;
    return await _requestVaClient.RequestVaAsyncVAlpha(setupConfiguration, paymentRequestDto, path);
  }
}