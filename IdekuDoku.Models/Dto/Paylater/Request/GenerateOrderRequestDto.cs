using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.Paylater.Request;

public class GenerateOrderRequestDto
{
    [JsonPropertyName("order")]
    public Order? Order { get; set; }
    
    [JsonPropertyName("payment")]
    public Payment? Payment { get; set; }
    
    [JsonPropertyName("customer")]
    public Customer? Customer { get; set; }
}