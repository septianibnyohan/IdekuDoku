using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace IdekuDoku.Models.Dto.Va.Payment.Request;

public class OrderRequestDto
{
  [JsonPropertyName("invoice_number")]
  public string InvoiceNumber { get; set; }

  [JsonPropertyName("amount")]
  public string Amount { get; set; }

  [JsonPropertyName("min_amount")]
  public string MinAmount { get; set; }

  [JsonPropertyName("max_amount")]
  public string MaxAmount { get; set; }
}