using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.EMoney;

public class Client
{
    [JsonPropertyName("id")]
    public String? Id { get; set; }
}