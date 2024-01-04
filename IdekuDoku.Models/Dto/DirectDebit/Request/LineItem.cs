using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.DirectDebit.Request;

public class LineItem
{
    [JsonPropertyName("name")]
    public String? Name { get; set; }
    
    [JsonPropertyName("price")]
    public long Price { get; set; }
    
    [JsonPropertyName("quantity")]
    public Int32 Quantity { get; set; }
}