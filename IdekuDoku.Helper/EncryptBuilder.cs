namespace IdekuDoku.Helper;

public class EncryptBuilder
{
  public static string? BuildSha256(string input)
  {
    // Implement your SHA-256 hash generation logic here
    using (var sha256 = System.Security.Cryptography.SHA256.Create())
    {
      byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
      byte[] hash = sha256.ComputeHash(bytes);
      return BitConverter.ToString(hash).Replace("-", "").ToLower();
    }
  }
}