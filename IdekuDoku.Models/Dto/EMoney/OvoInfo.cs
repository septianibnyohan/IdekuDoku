using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.EMoney;

public class OvoInfo
{
    [JsonPropertyName("ovo_id")]
    public String? OvoId { get; set; }
}