using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.O2O.Request;

public class AlfaInfo
{
    [JsonPropertyName("receipt")]
    public Receipt? Receipt { get; set; }
}