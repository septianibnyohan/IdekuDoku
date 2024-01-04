namespace IdekuDoku.Lib.Pojo;

public enum ServerLocation
{
  SANDBOX,
  PRODUCTION,
  SIT
}

public static class ServerLocationExtensions
{
  public static string? GetUrl(this ServerLocation location)
  {
    switch (location)
    {
      case ServerLocation.SANDBOX:
        return "https://api-sandbox.doku.com";
      case ServerLocation.PRODUCTION:
        return "https://api.doku.com";
      case ServerLocation.SIT:
        return "http://api-sit.doku.com";
      default:
        throw new ArgumentOutOfRangeException();
    }
  }
}