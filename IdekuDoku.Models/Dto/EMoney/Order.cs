using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.EMoney;

public class Order
{
    [JsonPropertyName("invoice_number")]
    public String? InvoiceNumber { get; set; }
    
    [JsonPropertyName("amount")]
    public long Amount { get; set; }
}