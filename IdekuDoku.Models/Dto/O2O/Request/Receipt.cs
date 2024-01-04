using System.Text.Json.Serialization;

namespace IdekuDoku.Models.Dto.O2O.Request;

public class Receipt
{
    [JsonPropertyName("footer_message")]
    public String? FooterMesssage { get; set; }
}