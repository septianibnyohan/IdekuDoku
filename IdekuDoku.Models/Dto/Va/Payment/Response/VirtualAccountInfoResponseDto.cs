using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.Va.Payment.Response;

public class VirtualAccountInfoResponseDto
{
  [JsonPropertyName("virtual_account_number")]
  public string? VirtualAccountNumber { get; set; }

  [JsonPropertyName("how_to_pay_page")]
  public string? HowToPayPage { get; set; }

  [JsonPropertyName("how_to_pay_api")]
  public string? HowToPayApi { get; set; }

  [JsonPropertyName("created_date")]
  public string? CreatedDate { get; set; }

  [JsonPropertyName("expired_date")]
  public string? ExpiredDate { get; set; }
}