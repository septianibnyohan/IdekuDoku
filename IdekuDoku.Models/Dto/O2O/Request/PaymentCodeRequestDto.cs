using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.O2O.Request;

public class PaymentCodeRequestDto
{
    [JsonPropertyName("order")]
    public Order? Order { get; set; }
    
    [JsonPropertyName("online_to_offline_info")]
    public OnlineToOfflineInfo? OnlineToOfflineInfo { get; set; }
    
    [JsonPropertyName("customer")]
    public Customer? Customer { get; set; }
    
    [JsonPropertyName("alfa_info")]
    public AlfaInfo? AlfaInfo { get; set; }
}