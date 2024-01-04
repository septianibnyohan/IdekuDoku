using IdekuDoku.Models.Dto.Va;
using IdekuDoku.Models.Dto.Va.Payment.Request;
using IdekuDoku.Models.Dto.Va.Payment.Response;
using IdekuDoku.Lib.Pojo;
using IdekuDoku.Domain.Entities;
using VirtualAccountInfo = IdekuDoku.Models.Dto.Va.Payment.Request.VirtualAccountInfo;

namespace IdekuDoku.Api.Services.Va;

public class GeneratePaymentCodeServices
{
    private readonly SetupConfigurationVaServices _setupConfigurationServices;

    private readonly VaServices _vaServices;
    //private readonly TransactionServices _transactionServices;
    //private readonly string _env;
    
    public GeneratePaymentCodeServices(SetupConfigurationVaServices setupConfigurationServices, VaServices vaServices)
    {
        _setupConfigurationServices = setupConfigurationServices;
        _vaServices = vaServices;
        //_transactionServices = transactionServices;
        //_env = env;
        //this._setupConfigurationServices = new SetupConfigurationVaServices();
        //this.transactionServices = new TransactionServices();
    }

    public Task<PaymentResponseDto?> Generate(PaymentCodeInboundDto paymentCodeInboundDto)
    //public Task<PaymentResponseDto?> Generate(VaPaymentCodeRequestDto paymentCodeInboundDto)
    {
        SetupConfigurationVa? setupConfigurationEntity = _setupConfigurationServices.FindOne();

        SetupConfiguration setupConfigurationLibrary = new SetupConfiguration
        {
            ClientId = setupConfigurationEntity?.ClientId,
            Key = setupConfigurationEntity?.SharedKey,
            Environment = setupConfigurationEntity?.Environment,
            //ServerLocation = setupConfigurationEntity.SetupServerLocation
        };

        var vaPaymentCodeRequestDto = new VaPaymentCodeRequestDto
        {
            Order = new OrderRequest
            {
                InvoiceNumber = paymentCodeInboundDto.InvoiceNumber,
                Amount = paymentCodeInboundDto.Amount
            },
            VirtualAccountInfo = new VirtualAccountInfo
            {
                ExpiredTime = paymentCodeInboundDto.ExpiredTime,
                ReusableStatus = paymentCodeInboundDto.ReusableStatus,
                Info1 = paymentCodeInboundDto.Info1,
                Info2 = paymentCodeInboundDto.Info2,
                Info3 = paymentCodeInboundDto.Info3
            },
            Customer = new CustomerRequest
            {
                Email = paymentCodeInboundDto.Email,
                Name = paymentCodeInboundDto.CustomerName
            }
        };
        
        return GeneratePaycodeVBeta(setupConfigurationLibrary, vaPaymentCodeRequestDto);

        /*
        var bank = new Bank
        {
            Amount = 100000,
            BankId = "1",
            Type = "bank"
        };

        var paymentCodeRequestDtoLib = new PaymentRequestDto
        {
            Customer = new CustomerRequestDto
            {
                Email = paymentCodeInboundDto.Email,
                Name = paymentCodeInboundDto.CustomerName
            },
            Order = new OrderRequestDto
            {
                InvoiceNumber = RandomString(),
                Amount = paymentCodeInboundDto.Amount
            },
            VirtualAccountInfo = new VirtualAccountInfoRequestDto
            {
                ExpiredTime = paymentCodeInboundDto.ExpiredTime,
                ReusableStatus = paymentCodeInboundDto.ReusableStatus,
                Info1 = paymentCodeInboundDto.Info1,
                Info2 = paymentCodeInboundDto.Info2,
                Info3 = paymentCodeInboundDto.Info3
            },
            AdditionalInfo = new Dictionary<string, object>()
        };

        paymentCodeRequestDtoLib.AdditionalInfo.Add("settlement", new List<Bank> { bank });

        return GeneratePaycode(paymentCodeInboundDto, setupConfigurationLibrary, paymentCodeRequestDtoLib);
        */
    }
    
    private async Task<PaymentResponseDto?> GeneratePaycodeVBeta(SetupConfiguration setupConfiguratioLibrary, VaPaymentCodeRequestDto paymentRequestDto)
    {
        //VaServices vaServices = new VaServices();
        PaymentResponseDto? paymentCodeResponseDto = new PaymentResponseDto();

        _vaServices.GenerateVa(setupConfiguratioLibrary, paymentRequestDto);

        return paymentCodeResponseDto;
    }

    private async Task<PaymentResponseDto?> GeneratePaycode(PaymentCodeInboundDto paymentCodeInboundDto, SetupConfiguration setupConfiguratioLibrary, PaymentRequestDto paymentRequestDto)
    {
        //VaServices vaServices = new VaServices();
        PaymentResponseDto? paymentCodeResponseDto = new PaymentResponseDto();

        if ("doku-va".Equals(paymentCodeInboundDto.Channel))
        {
            paymentCodeResponseDto = await _vaServices.GenerateDokuVa(setupConfiguratioLibrary, paymentRequestDto);
        }
        else if ("bca-va".Equals(paymentCodeInboundDto.Channel))
        {
            paymentCodeResponseDto = await _vaServices.GenerateBcaVa(setupConfiguratioLibrary, paymentRequestDto);
        }
        else if ("mandiri-va".Equals(paymentCodeInboundDto.Channel))
        {
            paymentCodeResponseDto = await _vaServices.GenerateMandiriVa(setupConfiguratioLibrary, paymentRequestDto);
        }
        else if ("bsm-va".Equals(paymentCodeInboundDto.Channel))
        {
            paymentCodeResponseDto = await _vaServices.GenerateBsmVa(setupConfiguratioLibrary, paymentRequestDto);
        }
        else if ("permata-va".Equals(paymentCodeInboundDto.Channel))
        {
            paymentCodeResponseDto = await _vaServices.GeneratePermataVa(setupConfiguratioLibrary, paymentRequestDto);
        }

        return paymentCodeResponseDto;
    }

    private string RandomString()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, 7)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}