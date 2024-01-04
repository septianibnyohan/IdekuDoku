using System.Text.Json;
using IdekuDoku.Lib.Constant;
using IdekuDoku.Lib.Helper;
using IdekuDoku.Lib.Settings;
using IdekuDoku.Models.Dto.Jokul.Request;
using IdekuDoku.Models.Dto.Jokul.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace IdekuDoku.Api.Controllers;

[Route("api/[controller]")]
public class JokulController : Controller
{
    private readonly IDokuSettings _dokuSettings;

    public JokulController(IDokuSettings dokuSettings)
    {
        _dokuSettings = dokuSettings;
    }
  
    [HttpPost("checkout")]
    public async Task<IActionResult> Checkout([FromBody] JokulRequest jokulRequest)
    {
        DateTime currentDate = DateTime.UtcNow;
    
        string? requestId = Guid.NewGuid().ToString();
        string? requestTimestamp = currentDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
        const string requestTarget = DokuUrl.CHECKOUT_INITIATE_PAYMENT;
    
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

        string jsonString = JsonSerializer.Serialize(jokulRequest, options);
    
        var digest = DokuCrypt.GenerateDigest(jsonString);
        var signature = DokuCrypt.GenerateSignature(_dokuSettings.ClientId, requestId, requestTimestamp, requestTarget, digest, _dokuSettings.ClientSecret);

    
        var res = await DokuApiBase.DoCheckoutInitiatePayment(_dokuSettings.ClientId, requestId, requestTimestamp, signature, jsonString);
        var objResp = JsonConvert.DeserializeObject<JokulResponse>(res);
    
        return Ok(objResp);
    }
}