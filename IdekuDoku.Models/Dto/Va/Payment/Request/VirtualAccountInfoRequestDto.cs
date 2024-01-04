using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.Va.Payment.Request;

public class VirtualAccountInfoRequestDto
{
  [JsonPropertyName("expired_time")]
  public int ExpiredTime { get; set; }

  [JsonPropertyName("reusable_status")]
  public bool ReusableStatus { get; set; }

  [JsonPropertyName("info1")]
  public string Info1 { get; set; }

  [JsonPropertyName("info2")]
  public string Info2 { get; set; }

  [JsonPropertyName("info3")]
  public string Info3 { get; set; }
}