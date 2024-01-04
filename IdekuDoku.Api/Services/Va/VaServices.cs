using System.Text.Json;
using IdekuDoku.Lib.Client.Va;
using IdekuDoku.Lib.Pojo;
using IdekuDoku.Models.Dto.Va.Payment.Request;
using IdekuDoku.Models.Dto.Va.Payment.Response;

namespace IdekuDoku.Api.Services.Va;

public class VaServices
{
    private readonly DokuVaClient _dokuVaClient;
    private readonly BcaVaClient _bcaVaClient;
    private readonly MandiriVaClient _mandiriVaClient;
    private readonly BsmVaClient _bsmVaClient;
    private readonly PermataVaClient _permataVaClient;
    
    public VaServices(
        DokuVaClient dokuVaClient,
        BcaVaClient bcaVaClient,
        MandiriVaClient mandiriVaClient,
        BsmVaClient bsmVaClient,
        PermataVaClient permataVaClient)
    {
        this._dokuVaClient = dokuVaClient;
        this._bcaVaClient = bcaVaClient;
        this._mandiriVaClient = mandiriVaClient;
        this._bsmVaClient = bsmVaClient;
        this._permataVaClient = permataVaClient;
    }

    public async Task<PaymentResponseDto?> GenerateVa(SetupConfiguration setupConfiguration, VaPaymentCodeRequestDto paymentRequestDto)
    {
        var response = await _bcaVaClient.GenerateBcaVaBeta(setupConfiguration, paymentRequestDto);
        return await DeserializeResponseAsync<PaymentResponseDto>(response);
    }
    
    public async Task<PaymentResponseDto?> GenerateDokuVa(SetupConfiguration setupConfiguration, PaymentRequestDto paymentRequestDto)
    {
        var response = await _dokuVaClient.GenerateDokuVa(setupConfiguration, paymentRequestDto);
        return await DeserializeResponseAsync<PaymentResponseDto>(response);
    }

    public async Task<PaymentResponseDto?> GenerateBcaVa(SetupConfiguration setupConfiguration, PaymentRequestDto paymentRequestDto)
    {
        var response = await _bcaVaClient.GenerateBcaVa(setupConfiguration, paymentRequestDto);
        return await DeserializeResponseAsync<PaymentResponseDto>(response);
    }

    public async Task<PaymentResponseDto?> GenerateMandiriVa(SetupConfiguration setupConfiguration, PaymentRequestDto paymentRequestDto)
    {
        var response = await _mandiriVaClient.GenerateMandiriVa(setupConfiguration, paymentRequestDto);
        return await DeserializeResponseAsync<PaymentResponseDto>(response);
    }

    public async Task<PaymentResponseDto?> GenerateBsmVa(SetupConfiguration setupConfiguration, PaymentRequestDto paymentRequestDto)
    {
        var response = await _bsmVaClient.GenerateBsmVa(setupConfiguration, paymentRequestDto);
        return await DeserializeResponseAsync<PaymentResponseDto>(response);
    }

    public async Task<PaymentResponseDto?> GeneratePermataVa(SetupConfiguration setupConfiguration, PaymentRequestDto paymentRequestDto)
    {
        var response = await _permataVaClient.GeneratePermataVa(setupConfiguration, paymentRequestDto);
        return await DeserializeResponseAsync<PaymentResponseDto>(response);
    }

    private async Task<T?> DeserializeResponseAsync<T>(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content);
    }
}