using System.Text;
using IdekuDoku.Helper;
using IdekuDoku.Models.Dto.Jokul;

namespace IdekuDoku.Lib.Helper;

public class DokuCrypt
{
    public const String COLON_SYMBOL = ":";
  public const String NEW_LINE = "\n";
  
  public const String CLIENT_ID = "Client-Id";
  public const String REQUEST_ID = "Request-Id";
  public const String REQUEST_TIMESTAMP = "Request-Timestamp";
  public const String REQUEST_TARGET = "Request-Target";
  public const String DIGEST = "Digest";
  public const String SIGNATURE = "Signature";

  public static String GenerateDigest(String requestBody)
  {
    Byte[] digest = Crypto.ComputeSha256Hash(requestBody);

    var base64Digest = Crypto.Base64Encode(digest);

    return base64Digest;
  }

  public static String CreateWords(string? clientId, string? requestId, string? requestTimestamp, string requestTarget, string digest)
  {
    // Prepare Signature Component
    StringBuilder component = new StringBuilder();
    const string COLON_SYMBOL = ":";
    const string NEW_LINE = "\n";
    component.Append(CLIENT_ID).Append(COLON_SYMBOL).Append(clientId);
    component.Append(NEW_LINE);
    component.Append(REQUEST_ID).Append(COLON_SYMBOL).Append(requestId);
    component.Append(NEW_LINE);
    component.Append(REQUEST_TIMESTAMP).Append(COLON_SYMBOL).Append(requestTimestamp);

    if (!string.IsNullOrEmpty(requestTarget))
    {
      component.Append(NEW_LINE);
      component.Append(REQUEST_TARGET).Append(COLON_SYMBOL).Append(requestTarget);
    }
    
    // If body not sent when accessing API with HTTP method GET/DELETE
    if (!string.IsNullOrEmpty(digest))
    {
      component.Append(NEW_LINE);
      component.Append(DIGEST).Append(COLON_SYMBOL).Append(digest);
    }

    return component.ToString();
  }
  
  public static String CreateWords(SignatureComponent signatureComponent)
  {
    StringBuilder component = new StringBuilder();
    component.Append(signatureComponent.Amount);
    component.Append(signatureComponent.ApprovalCode);
    component.Append(signatureComponent.BatchNumber);
    component.Append(signatureComponent.ClientId);
    component.Append(signatureComponent.InvoiceNumber);
    component.Append(signatureComponent.OvoId);
    component.Append(signatureComponent.ReferenceNumber);
    component.Append(signatureComponent.TraceNumber);
    component.Append(signatureComponent.Key);

    return component.ToString();
  }
  
  public static string? GenerateSignature(string? clientId, string? requestId, string? requestTimestamp, string requestTarget, string digest, string? secret)
  {
    String component = CreateWords(clientId, requestId, requestTimestamp, requestTarget, digest);

    string? signature = Crypto.ComputeHmacSha256(component, secret);
    return "HMACSHA256=" + signature;
    return signature;
  }
  
  public static string CheckSum(SignatureComponent signatureComponent)
  {
    String component = CreateWords(signatureComponent);

    byte[] bSignature = Crypto.ComputeSha256Hash(component);
    string signature = BitConverter.ToString(bSignature).Replace("-", "");
    
    return signature;
  }
}