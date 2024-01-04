using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.DirectDebit.Request;

public class Customer
{
    [JsonPropertyName("id")]
    public String Id { get; set; }
    
    [JsonPropertyName("name")]
    public String Name { get; set; }
}