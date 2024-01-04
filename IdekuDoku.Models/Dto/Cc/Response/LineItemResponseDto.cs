using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IdekuDoku.Models.Dto.Cc.Response;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class LineItemResponseDto
{
  public string Name { get; set; }
  public long Price { get; set; }
  public int Quantity { get; set; }
}