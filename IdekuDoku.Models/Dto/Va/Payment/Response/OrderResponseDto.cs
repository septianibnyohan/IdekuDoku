using Newtonsoft.Json;

namespace IdekuDoku.Models.Dto.Va.Payment.Response;

public class OrderResponseDto
{
  [JsonProperty("invoice_number")]
  public string InvoiceNumber { get; set; }
}