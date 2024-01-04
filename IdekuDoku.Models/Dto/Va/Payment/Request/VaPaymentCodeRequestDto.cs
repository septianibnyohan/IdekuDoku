using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.Va.Payment.Request;

public class VaPaymentCodeRequestDto
{
    [JsonPropertyName("order")]
    public OrderRequest? Order { get; set; }
    
    [JsonPropertyName("virtual_account_info")]
    public VirtualAccountInfo? VirtualAccountInfo { get; set; }
    
    [JsonPropertyName("customer")]
    public CustomerRequest? Customer { get; set; }
}