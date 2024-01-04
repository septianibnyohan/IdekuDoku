using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.Va.Payment.Response;

public class VaPaymentCodeResponseDto
{
    [JsonPropertyName("order")]
    public Order? Order { get; set; }
    
    [JsonPropertyName("virtual_account_info")]
    public VirtualAccountInfo? VirtualAccountInfo { get; set; }
}