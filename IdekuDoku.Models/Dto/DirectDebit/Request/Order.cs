using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.DirectDebit.Request;

public class Order
{
    [JsonPropertyName("invoice_number")]
    public String? InvoiceNumber { get; set; }
    
    [JsonPropertyName("line_items")]
    public LineItem[]? LineItems { get; set; }
}