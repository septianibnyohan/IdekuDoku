using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IdekuDoku.Models.Dto.Cc.Request;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SecurityRequestDto
{
  [JsonProperty("signature")]
  public string? Signature { get; set; }
}