using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.DirectDebit.Request;

public class Acquirer
{
    [JsonPropertyName("id")]
    public String? Id { get; set; }
}