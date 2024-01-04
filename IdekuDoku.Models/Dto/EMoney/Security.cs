using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.EMoney;

public class Security
{
    [JsonPropertyName("check_sum")]
    public String? CheckSum { get; set; }
}