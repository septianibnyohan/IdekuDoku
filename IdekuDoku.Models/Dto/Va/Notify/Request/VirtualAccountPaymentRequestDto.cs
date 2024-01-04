using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace IdekuDoku.Models.Dto.Va.Notify.Request;

public class VirtualAccountPaymentRequestDto
{
  [JsonPropertyName("date")]
  public string Date { get; set; }

  [JsonPropertyName("systrace_number")]
  public string SystraceNumber { get; set; }
}