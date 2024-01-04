using IdekuDoku.Lib.Constant;
using IdekuDoku.Lib.Pojo;
using IdekuDoku.Models.Dto.Va.Payment.Request;

namespace IdekuDoku.Lib.Client.Va;

public class PermataVaClient
{
  private readonly RequestVaClient _requestVaClient;

  public PermataVaClient(RequestVaClient requestVaClient)
  {
    this._requestVaClient = requestVaClient;
  }

  public async Task<HttpResponseMessage> GeneratePermataVa(SetupConfiguration setupConfiguration, PaymentRequestDto paymentRequestDto)
  {
    string path = "/permata-virtual-account/v2/payment-code";
    return await _requestVaClient.RequestVaAsync(setupConfiguration, paymentRequestDto, path);
  }
  
  public async Task<HttpResponseMessage> GeneratePermataVa(SetupConfiguration setupConfiguration, VaPaymentCodeRequestDto paymentRequestDto)
  {
    string path = DokuUrl.PERMATA_VA_GENERATE_PAYMENT_CODE;
    return await _requestVaClient.RequestVaAsyncVAlpha(setupConfiguration, paymentRequestDto, path);
  }
}