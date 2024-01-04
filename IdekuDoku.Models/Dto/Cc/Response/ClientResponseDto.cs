using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IdekuDoku.Models.Dto.Cc.Response;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ClientResponseDto
{
  public string Id { get; set; }
}