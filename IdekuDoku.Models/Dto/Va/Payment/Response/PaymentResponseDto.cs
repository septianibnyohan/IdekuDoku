using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.Va.Payment.Response;

public class PaymentResponseDto
{
  [JsonPropertyName("order")]
  public OrderResponseDto Order { get; set; }

  [JsonPropertyName("virtual_account_info")]
  public VirtualAccountInfoResponseDto VirtualAccountInfo { get; set; }
}