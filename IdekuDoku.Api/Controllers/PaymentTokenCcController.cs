using IdekuDoku.Api.Services.Cc;
using IdekuDoku.Domain.Entities;
using IdekuDoku.Models.Dto.Cc;
using IdekuDoku.Models.Dto.Cc.Request;
using Microsoft.AspNetCore.Mvc;

namespace IdekuDoku.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentTokenCcController : ControllerBase
{
  private readonly PaymentTokenServices _paymentTokenServices;

  public PaymentTokenCcController(PaymentTokenServices paymentTokenServices)
  {
    _paymentTokenServices = paymentTokenServices;
  }

  [HttpGet]
  public IActionResult GetPaycode()
  {
    return Ok("payment-token-cc");
  }

  [HttpPost]
  // [Consumes("application/json")]
  // [Produces("application/json")]
  public async Task<IActionResult> Generate([FromBody] CcGeneratePaymentRequestDto paymentTokenRequestDto)
  {
    try
    {
      TransactionCc? transaction = await _paymentTokenServices.RequestToken(paymentTokenRequestDto);
      return Ok(transaction);
    }
    catch (IOException ex)
    {
      return StatusCode(500, new { error = ex.Message });
    }
  }

  [HttpGet("callback")]
  public IActionResult Callback()
  {
    return Ok("callback-page");
  }
}