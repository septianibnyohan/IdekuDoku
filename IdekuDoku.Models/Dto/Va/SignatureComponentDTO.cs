namespace IdekuDoku.Models.Dto.Va;

public class SignatureComponentDTO
{
  public string HttpMethod { get; set; }
  public string ClientId { get; set; }
  public string RequestId { get; set; }
  public string? RequestTarget { get; set; }
  public string Timestamp { get; set; }
  public string MessageBody { get; set; }
  public string? SecretKey { get; set; }
}
