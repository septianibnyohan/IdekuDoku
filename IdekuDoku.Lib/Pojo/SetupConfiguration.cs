namespace IdekuDoku.Lib.Pojo;

public class SetupConfiguration
{
  public string? ClientId { get; set; }
  public string? Key { get; set; }
  public string? Environment { get; set; }

  public string? ServerLocation
  {
    get
    {
      if ("sandbox".Equals(this.Environment, StringComparison.OrdinalIgnoreCase))
      {
        return Pojo.ServerLocation.SANDBOX.GetUrl(); //ServerLocation.SANDBOX.GetUrl();
      }
      else if ("production".Equals(this.Environment, StringComparison.OrdinalIgnoreCase))
      {
        return Pojo.ServerLocation.PRODUCTION.GetUrl();
      }
      else
      {
        return this.Environment;
      }
    }
  }
}