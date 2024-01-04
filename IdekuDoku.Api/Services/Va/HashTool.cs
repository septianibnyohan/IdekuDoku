using System.Security.Cryptography;
using System.Text;

namespace IdekuDoku.Api.Services.Va;

public static class HashTool
{
  public static string Sha256Base64(string input)
  {
    using SHA256 sha256 = SHA256.Create();
    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
    byte[] hashBytes = sha256.ComputeHash(inputBytes);
    return Convert.ToBase64String(hashBytes);
  }

  public static string HmacSha256(string input, string? secret)
  {
    using HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret ?? throw new ArgumentNullException(nameof(secret))));
    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
    byte[] hashBytes = hmac.ComputeHash(inputBytes);
    return Convert.ToBase64String(hashBytes);
  }
}