using System.Text;

namespace IdekuDoku.Lib.Helper;

public class HttpRequest
{
  public static async Task<string>  Curl(string url, Dictionary<string, string?> headers, string bodyContent)
  {
    
    var client = new HttpClient();
    var request = new HttpRequestMessage(HttpMethod.Post, url);

    foreach (var header in headers)
    {
      request.Headers.Add(header.Key, header.Value);
    }
    
    //var content = new StringContent(bodyContent);
    var content = new StringContent(bodyContent, Encoding.UTF8, "application/json");
    request.Content = content;
    var response = await client.SendAsync(request);
    //response.EnsureSuccessStatusCode();
    
    Console.WriteLine(await response.Content.ReadAsStringAsync());
    return await response.Content.ReadAsStringAsync();
  }

  public static async Task<HttpResponseMessage> CurlVBeta(string url, Dictionary<string, string?> headers, string bodyContent)
  {

    var client = new HttpClient();
    var request = new HttpRequestMessage(HttpMethod.Post, url);

    foreach (var header in headers)
    {
      request.Headers.Add(header.Key, header.Value);
    }

    //var content = new StringContent(bodyContent);
    var content = new StringContent(bodyContent, Encoding.UTF8, "application/json");
    request.Content = content;
    var response = await client.SendAsync(request);

    return response;
  }

  public static async Task<string> Curl(string url, Dictionary<string, string?> headers)
  {
    return await Curl(url, headers, null);
  }
}