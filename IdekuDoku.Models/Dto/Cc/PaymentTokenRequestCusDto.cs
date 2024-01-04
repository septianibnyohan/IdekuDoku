using IdekuDoku.Models.Dto.Cc.Request;
using Newtonsoft.Json;

namespace IdekuDoku.Models.Dto.Cc;

public class PaymentTokenRequestCusDto
{
  [JsonProperty("customer")]
  public CustomerRequestDto Customer { get; set; }

  [JsonProperty("order")]
  public CcOrderRequestDto CcOrder { get; set; }
}