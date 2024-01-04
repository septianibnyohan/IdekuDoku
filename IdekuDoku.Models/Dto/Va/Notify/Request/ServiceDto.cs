using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace IdekuDoku.Models.Dto.Va.Notify.Request;

public class ServiceDto
{
  [JsonPropertyName("id")]
  public string Id { get; set; }
}