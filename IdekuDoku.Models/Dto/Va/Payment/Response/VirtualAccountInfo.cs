using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.Va.Payment.Response;

public abstract class VirtualAccountInfo
{
    [JsonPropertyName("virtual_account_number")]
    public String? VirtualAccountNumber { get; set; }
    
    [JsonPropertyName("how_to_pay_page")]
    public String? HowToPayPage { get; set; }
    
    [JsonPropertyName("how_to_pay_api")]
    public String? HowToPayApi { get; set; }
    
    [JsonPropertyName("created_date")]
    public String? CreatedDate { get; set; }
    
    [JsonPropertyName("expired_date")]
    public String? ExpiredDate { get; set; }
    
    [JsonPropertyName("created_date_utc")]
    public String? CreatedDateUtc { get; set; }
    
    [JsonPropertyName("expired_date_utc")]
    public String? ExpiredDateUtc { get; set; }
}