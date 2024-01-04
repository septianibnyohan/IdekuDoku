using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.EMoney;

public class PaymentRequestDto
{
    [JsonPropertyName("client")]
    public Client? Client { get; set; }
    
    [JsonPropertyName("order")]
    public Order? Order { get; set; }
    
    [JsonPropertyName("ovo_info")]
    public OvoInfo? OvoInfo { get; set; }
    
    [JsonPropertyName("security")]
    public Security? Security { get; set; }
}