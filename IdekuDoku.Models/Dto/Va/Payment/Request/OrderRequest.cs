using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.Va.Payment.Request;

public class OrderRequest
{
    [JsonPropertyName("invoice_number")]
    public string? InvoiceNumber { get; set; }
    
    [JsonPropertyName("amount")]
    public long Amount { get; set; }
}