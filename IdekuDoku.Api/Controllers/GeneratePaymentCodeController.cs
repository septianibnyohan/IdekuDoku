using IdekuDoku.Api.Services.Va;
using IdekuDoku.Models.Dto.Va;
using IdekuDoku.Models.Dto.Va.Payment.Request;
using IdekuDoku.Models.Dto.Va.Payment.Response;
using Microsoft.AspNetCore.Mvc;

namespace IdekuDoku.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GeneratePaymentCodeController : ControllerBase
{
  private readonly GeneratePaymentCodeServices _generatePaymentCodeServices;
  
  public GeneratePaymentCodeController(GeneratePaymentCodeServices generatePaymentCodeServices)
  {
    this._generatePaymentCodeServices = generatePaymentCodeServices;
  }

  [HttpGet]
  public IActionResult GetPaycode()
  {
    return Ok();
  }

  [HttpPost]
  // public async Task<IActionResult> Generate([FromBody] PaymentCodeInboundDto paymentCodeInboundDto)
  public async Task<IActionResult> Generate([FromBody] PaymentCodeInboundDto paymentCodeInboundDto)
  {
    try
    {
      //PaymentResponseDto? paymentCodeResponseDto = await _generatePaymentCodeServices.Generate(paymentCodeInboundDto);
      PaymentResponseDto? paymentCodeResponseDto = await _generatePaymentCodeServices.Generate(paymentCodeInboundDto);
      return Ok(paymentCodeResponseDto);
    }
    catch (IOException ex)
    {
      // Handle the exception, e.g., log it or return an error response.
      return BadRequest($"Error: {ex.Message}");
    }
  }
}