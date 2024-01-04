using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IdekuDoku.Models.Dto.Cc.Response;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class OrderResponsetDto
{
  public string InvoiceNumber { get; set; }
  public List<LineItemResponseDto> LineItems { get; set; } = new List<LineItemResponseDto>();
  public long Amount { get; set; }
  public string CreatedDate { get; set; }
  public string SessionId { get; set; }
}