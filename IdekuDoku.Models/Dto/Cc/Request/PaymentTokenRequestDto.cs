using IdekuDoku.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IdekuDoku.Models.Dto.Cc.Request;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class PaymentTokenRequestDto
{
  public ClientRequestDto Client { get; set; }
  public CustomerRequestDto Customer { get; set; }
  public CcOrderRequestDto CcOrder { get; set; }
  public SecurityRequestDto Security { get; set; }

  public PaymentTokenRequestDto()
  {
    Security = new SecurityRequestDto();
  }

  public PaymentTokenRequestDto(string? sharedKey) : this()
  {
    // Initialize Security.Signature based on sharedKey
    string words = Client.Id + CcOrder.InvoiceNumber + CcOrder.Amount + sharedKey;
    Security.Signature = EncryptBuilder.BuildSha256(words);
  }

  public void Init(string? sharedKey)
  {
    string words = Client.Id + CcOrder.InvoiceNumber + CcOrder.Amount + sharedKey;
    Security.Signature = EncryptBuilder.BuildSha256(words);
  }
}