using System.Dynamic;
using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.Paylater.Request;

public class LineItem
{
    [JsonPropertyName("name")]
    public String? Name { get; set; }
    
    [JsonPropertyName("price")]
    public String? Price { get; set; }
    
    [JsonPropertyName("quantity")]
    public String? Quantity { get; set; }
    
    [JsonPropertyName("sku")]
    public String? Sku { get; set; }
    
    [JsonPropertyName("category")]
    public String? Category { get; set; }
}