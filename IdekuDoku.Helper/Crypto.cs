using System.Security.Cryptography;
using System.Text;

namespace IdekuDoku.Helper;

public class Crypto
{
    public static byte[] ComputeSha256Hash(string requestBody)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] data = Encoding.UTF8.GetBytes(requestBody);
            byte[] digest = sha256.ComputeHash(data);

            return digest;
        }
    }

    public static string? ComputeHmacSha256(string component, string? secret)
    {
        // Calculate HMAC-SHA256 base64 from all the components above
        byte[] decodedKey = Encoding.UTF8.GetBytes(secret);
        using (HMACSHA256 hmacSha256 = new HMACSHA256(decodedKey))
        {
            byte[] componentBytes = Encoding.UTF8.GetBytes(component);
            byte[] hmacSha256DigestBytes = hmacSha256.ComputeHash(componentBytes);
            string? signature = Convert.ToBase64String(hmacSha256DigestBytes);

            return signature;
        }
    }
  
    public static string Base64Encode(string plainText) 
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }
  
    public static string Base64Encode(byte[] plainTextBytes) 
    {
        return System.Convert.ToBase64String(plainTextBytes);
    }
}