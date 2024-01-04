using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.Va.Payment.Request;

public class VirtualAccountInfo
{
    [JsonPropertyName("virtual_account_number")]
    public string? VirtualAccountNumber { get; set; }
    
    [JsonPropertyName("expired_time")]
    public Int32 ExpiredTime { get; set; }
    
    [JsonPropertyName("reusable_status")]
    public Boolean ReusableStatus { get; set; }
    
    [JsonPropertyName("info1")]
    public string? Info1 { get; set; }
    
    [JsonPropertyName("info2")]
    public string? Info2 { get; set; }
    
    [JsonPropertyName("info3")]
    public string? Info3 { get; set; }
}