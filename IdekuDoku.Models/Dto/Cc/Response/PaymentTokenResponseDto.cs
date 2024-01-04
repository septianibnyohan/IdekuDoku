using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IdekuDoku.Models.Dto.Cc.Response;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class PaymentTokenResponseDto
{
  public ClientResponseDto Client { get; set; }
  public OrderResponsetDto Order { get; set; }
  public CCPaymentPageResponseDto CreditCardPaymentPage { get; set; }
}