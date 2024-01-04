using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IdekuDoku.Models.Dto.Cc.Request;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class LineItemRequestDto
{
  [JsonPropertyName("name")]
  public string Name { get; set; }
  
  [JsonPropertyName("quantity")]
  public int Quantity { get; set; }
  
  [JsonPropertyName("price")]
  public long Price { get; set; }
}