using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.O2O.Request;

public class Customer
{
    [JsonPropertyName("name")]
    public String? Name { get; set; }
    
    [JsonPropertyName("email")]
    public String? Email { get; set; }
}