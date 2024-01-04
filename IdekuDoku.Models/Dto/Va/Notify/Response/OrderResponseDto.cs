using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IdekuDoku.Models.Dto.Va.Notify.Response;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class OrderResponseDto
{
  public string InvoiceNumber { get; set; }
  public long Amount { get; set; }
}