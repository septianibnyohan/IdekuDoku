using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.DirectDebit.Request;

public class PaymentRequestDto
{
    [JsonPropertyName("channel")]
    public Channel? Channel { get; set; }
    
    [JsonPropertyName("acquirer")]
    public Acquirer? Acquirer { get; set; }
    
    [JsonPropertyName("customer")]
    public Customer? Customer { get; set; }
    
    [JsonPropertyName("order")]
    public Order? Order { get; set; }
}