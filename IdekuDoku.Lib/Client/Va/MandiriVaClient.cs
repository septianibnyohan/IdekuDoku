using IdekuDoku.Lib.Constant;
using IdekuDoku.Lib.Pojo;
using IdekuDoku.Models.Dto.Va.Payment.Request;

namespace IdekuDoku.Lib.Client.Va;

public class MandiriVaClient
{
  private readonly RequestVaClient _requestVaClient;
  
  public MandiriVaClient(RequestVaClient requestVaClient)
  {
    this._requestVaClient = requestVaClient;
  }

  public async Task<HttpResponseMessage> GenerateMandiriVa(SetupConfiguration setupConfiguration, PaymentRequestDto paymentRequestDto)
  {
    string path = "/mandiri-virtual-account/v2/payment-code";
    return await _requestVaClient.RequestVaAsync(setupConfiguration, paymentRequestDto, path);
  }
  
  public async Task<HttpResponseMessage> GenerateMandiriVa(SetupConfiguration setupConfiguration, VaPaymentCodeRequestDto paymentRequestDto)
  {
    string path = DokuUrl.MANDIRI_VA_GENERATE_PAYMENT_CODE;
    return await _requestVaClient.RequestVaAsyncVAlpha(setupConfiguration, paymentRequestDto, path);
  }
}