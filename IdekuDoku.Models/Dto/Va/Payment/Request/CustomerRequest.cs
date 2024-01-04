using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.Va.Payment.Request;

public class CustomerRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("email")]
    public string? Email { get; set; }
}