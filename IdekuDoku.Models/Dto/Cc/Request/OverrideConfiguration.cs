using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace IdekuDoku.Models.Dto.Cc.Request;

public class OverrideConfiguration
{
    [JsonPropertyName("themes")]
    public Themes? Themes { get; set; }
}