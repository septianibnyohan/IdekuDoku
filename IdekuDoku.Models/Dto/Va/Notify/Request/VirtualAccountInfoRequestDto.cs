using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace IdekuDoku.Models.Dto.Va.Notify.Request;

public class VirtualAccountInfoRequestDto
{
  [JsonPropertyName("virtual_account_number")]
  public string? VirtualAccountNumber { get; set; }
}