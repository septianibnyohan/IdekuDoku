using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IdekuDoku.Models.Dto.Cc.Request;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ClientRequestDto
{
  [JsonProperty("id")]
  public string? Id { get; set; }
}