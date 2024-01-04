using Newtonsoft.Json;

namespace IdekuDoku.Models.Dto.Va.Notify.Request;

public class NotifyRequestHeader
{
  [JsonProperty("Client-Id")]
  public string ClientId { get; set; }
        
  [JsonProperty("Signature")]
  public string Signature { get; set; }
        
  [JsonProperty("Request-Id")]
  public string RequestId { get; set; }
        
  [JsonProperty("Request-Timestamp")]
  public string RequestTimeStamp { get; set; }
}