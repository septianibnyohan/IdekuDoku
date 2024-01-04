using IdekuDoku.Api.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
  private readonly PaymentService _paymentService;

  public PaymentController(PaymentService paymentService)
  {
    _paymentService = paymentService;
  }

  [HttpPost("process-payment/{userId}")]
  public IActionResult ProcessPayment(int userId)
  {
    try
    {
      _paymentService.ProcessPayment(userId);
      return Ok("Payment processed successfully.");
    }
    catch (Exception ex)
    {
      // Log the exception
      return BadRequest($"Failed to process payment: {ex.Message}");
    }
  }
}