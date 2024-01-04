using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.Va;

public class Bank
{
  [JsonPropertyName("bank_id")]
  public string BankId { get; set; }

  [JsonPropertyName("type")]
  public string Type { get; set; }

  [JsonPropertyName("amount")]
  public int Amount { get; set; }
}