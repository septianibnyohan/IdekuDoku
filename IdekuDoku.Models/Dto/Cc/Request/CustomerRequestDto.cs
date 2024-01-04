using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace IdekuDoku.Models.Dto.Cc.Request;

public class CustomerRequestDto
{
  [JsonPropertyName("id")]
  public string? Id { get; set; }

  [JsonPropertyName("name")]
  public string? Name { get; set; }

  [JsonPropertyName("email")]
  public string? Email { get; set; }

  [JsonPropertyName("phone")]
  public string? Phone { get; set; }

  [JsonPropertyName("address")]
  public string? Address { get; set; }

  [JsonPropertyName("country")]
  public string? Country { get; set; }
}