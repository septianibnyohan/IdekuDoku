using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.Paylater.Request;

public class Payment
{
    [JsonPropertyName("merchant_unique_reference")]
    public String? MerchantUniqueReference { get; set; }
}