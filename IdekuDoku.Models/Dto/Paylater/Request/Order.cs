using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.Paylater.Request;

public class Order
{
    [JsonPropertyName("invoice_number")]
    public String? InvoiceNumber { get; set; }
    
    [JsonPropertyName("line_items")]
    public LineItem? LineItems { get; set; }
    
    [JsonPropertyName("amount")]
    public String? Amount { get; set; }
    
    [JsonPropertyName("callback_url")]
    public String? CallbackUrl { get; set; }
}