using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace IdekuDoku.Models.Dto.Cc.Request;

[DataContract(Name = "CcOrderRequestDto")]
public class CcOrderRequestDto
{
  [JsonPropertyName("amount")]
  public long Amount { get; set; }

  [JsonPropertyName("invoice_number")]
  public string? InvoiceNumber { get; set; }

  [JsonPropertyName("currency")]
  public string? Currency { get; set; }

  [JsonPropertyName("callback_url")]
  public string? CallbackUrl { get; set; }

  [JsonPropertyName("line_items")]
  public List<LineItemRequestDto>? LineItems { get; set; }

  [JsonPropertyName("created_date")]
  public string? CreatedDate { get; set; }

  [JsonPropertyName("session_id")]
  public string? SessionId { get; set; }
}