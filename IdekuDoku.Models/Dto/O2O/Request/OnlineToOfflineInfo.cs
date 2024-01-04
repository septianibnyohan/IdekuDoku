using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.O2O.Request;

public class OnlineToOfflineInfo
{
    [JsonPropertyName("expired_time")]
    public Int32 ExpiredTime { get; set; }
    
    [JsonPropertyName("reusable_status")]
    public Boolean ReusableStatus { get; set; }
    
    [JsonPropertyName("info")]
    public String? Info { get; set; }
}