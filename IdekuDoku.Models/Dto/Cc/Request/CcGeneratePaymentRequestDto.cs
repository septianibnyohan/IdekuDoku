using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace IdekuDoku.Models.Dto.Cc.Request;

[DataContract(Name = "CcGeneratePaymentRequestDto")]
public class CcGeneratePaymentRequestDto
{
    [JsonPropertyName("customer")]
    public CustomerRequestDto? Customer { get; set; }

    [JsonPropertyName("order")]
    public IdekuDoku.Models.Dto.Cc.Request.CcOrderRequestDto? Order { get; set; }
    
    [JsonPropertyName("override_configuration")]
    public OverrideConfiguration? OverrideConfiguration { get; set; }
}