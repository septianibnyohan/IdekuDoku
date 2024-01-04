using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IdekuDoku.Models.Dto.Cc.Response;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class CCPaymentPageResponseDto
{
  public string Url { get; set; }
  public string CreatedDate { get; set; }
}