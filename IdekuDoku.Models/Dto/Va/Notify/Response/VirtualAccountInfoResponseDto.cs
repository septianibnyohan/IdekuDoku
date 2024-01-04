using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IdekuDoku.Models.Dto.Va.Notify.Response;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class VirtualAccountInfoResponseDto
{
  public string? VirtualAccountNumber { get; set; }
}