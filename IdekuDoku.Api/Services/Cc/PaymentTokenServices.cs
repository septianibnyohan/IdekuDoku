using IdekuDoku.Domain.Entities;
using IdekuDoku.Lib.Pojo;
using IdekuDoku.Lib.Settings;
using IdekuDoku.Models.Dto.Cc;
using IdekuDoku.Models.Dto.Cc.Request;
using IdekuDoku.Models.Dto.Cc.Response;

namespace IdekuDoku.Api.Services.Cc;

public class PaymentTokenServices
{
    private readonly SetupConfigurationCcServices _setupConfigurationCcServices;
    private readonly TransactionCcServices _transactionCcServices;
    private readonly IDokuSettings _dokuSettings;

    public PaymentTokenServices(SetupConfigurationCcServices setupConfigurationCcServices, TransactionCcServices transactionCcServices, IDokuSettings dokuSettings)
    {
        _setupConfigurationCcServices = setupConfigurationCcServices;
        _transactionCcServices = transactionCcServices;
        _dokuSettings = dokuSettings;
    }

    public async Task<TransactionCc?> RequestToken(CcGeneratePaymentRequestDto paymentTokenRequestCusDto) //PaymentTokenRequestCusDto
    {
        CcService ccService = new CcService(_dokuSettings);
        SetupConfigurationCc? setupConfigurationEntity = _setupConfigurationCcServices.FindOne();

        SetupConfiguration setupConfigurationLibrary = new SetupConfiguration
        {
            ClientId = setupConfigurationEntity?.ClientId,
            Key = setupConfigurationEntity?.SharedKey,
            Environment = "https://api-sandbox.doku.com/"
        };

        List<IdekuDoku.Models.Dto.Cc.Request.LineItemRequestDto> lineItemRequestDtoList = new List<IdekuDoku.Models.Dto.Cc.Request.LineItemRequestDto>
        {
            new IdekuDoku.Models.Dto.Cc.Request.LineItemRequestDto
            {
                Name = paymentTokenRequestCusDto.Order.LineItems[0].Name,
                Price = paymentTokenRequestCusDto.Order.LineItems[0].Price,
                Quantity = paymentTokenRequestCusDto.Order.LineItems[0].Quantity
            }
        };

        PaymentTokenRequestDto paymentTokenRequestDto = new PaymentTokenRequestDto
        {
            Client = new ClientRequestDto { Id = setupConfigurationEntity?.ClientId },
            CcOrder = new CcOrderRequestDto
            {
                Amount = paymentTokenRequestCusDto.Order.Amount,
                CallbackUrl = paymentTokenRequestCusDto.Order.CallbackUrl,
                CreatedDate = paymentTokenRequestCusDto.Order.CreatedDate,
                Currency = paymentTokenRequestCusDto.Order.Currency,
                InvoiceNumber = paymentTokenRequestCusDto.Order.InvoiceNumber,
                LineItems = lineItemRequestDtoList,
                SessionId = paymentTokenRequestCusDto.Order.SessionId
            },
            Customer = new CustomerRequestDto
            {
                Id = paymentTokenRequestCusDto.Customer.Id,
                Address = paymentTokenRequestCusDto.Customer.Address,
                Country = paymentTokenRequestCusDto.Customer.Country,
                Email = paymentTokenRequestCusDto.Customer.Email,
                Phone = paymentTokenRequestCusDto.Customer.Phone,
                Name = paymentTokenRequestCusDto.Customer.Name
            }
        };
        
        paymentTokenRequestDto.Init(setupConfigurationLibrary.Key);

        PaymentTokenResponseDto? paymentTokenResponseDto = await ccService.GenerateTokenVBeta(setupConfigurationLibrary, paymentTokenRequestCusDto);
        return _transactionCcServices.Create(paymentTokenResponseDto);
    }
}