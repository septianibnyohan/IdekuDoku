namespace IdekuDoku.Models.Dto.Va;

public class SetupConfigurationDto
{
  public int Id { get; set; }
  public string? ClientId { get; set; }
  public string? SharedKey { get; set; }
  public string? Environment { get; set; }
}