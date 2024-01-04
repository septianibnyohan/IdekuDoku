using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.Va.Payment.Response;

public abstract class Order
{
    [JsonPropertyName("invoice_number")]
    public String? InvoiceNumber { get; set; }
}