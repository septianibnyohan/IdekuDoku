using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.Paylater.Request;

public class Customer
{
    [JsonPropertyName("id")]
    public String? Id { get; set; }
    
    [JsonPropertyName("name")]
    public String? Name { get; set; }
    
    [JsonPropertyName("phone")]
    public String? Phone { get; set; }
    
    [JsonPropertyName("address")]
    public String? Address { get; set; }
    
    [JsonPropertyName("postcode")]
    public String? PostCode { get; set; }
    
    [JsonPropertyName("state")]
    public String? State { get; set; }
    
    [JsonPropertyName("city")]
    public String? City { get; set; }
}