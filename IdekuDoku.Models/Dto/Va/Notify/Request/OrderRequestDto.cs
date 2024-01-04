using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.Va.Notify.Request;

[DataContract(Name = "VaOrderRequestDto")]
public class OrderRequestDto
{
  [JsonPropertyName("invoice_number")]
  public string InvoiceNumber { get; set; }

  [JsonPropertyName("amount")]
  public long Amount { get; set; }
}