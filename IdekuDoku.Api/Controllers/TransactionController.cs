using AutoMapper;
using IdekuDoku.Models.Dto.Va;
using IdekuDoku.Api.Services.Va;
using IdekuDoku.Domain.Entities;
using IdekuDoku.Models.Dto.Va;
using Microsoft.AspNetCore.Mvc;

namespace IdekuDoku.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
  private readonly TransactionServices _transactionServices;
  private readonly IMapper _mapper; // Injected instance of IMapper

  /*
  public TransactionController(TransactionServices transactionServices, IMapper mapper)
  {
    _transactionServices = transactionServices;
    _mapper = mapper;
  }
  */
    
  public TransactionController(TransactionServices transactionServices)
  {
    _transactionServices = transactionServices;
  }

  [HttpGet]
  public IActionResult GetTransactionForView()
  {
    return Ok("transaction");
  }

  [HttpGet("get-data")]
  public IActionResult GetData([FromQuery] string vaNumber)
  {
    Transaction? transactionEntity = _transactionServices.FindByVANumber(vaNumber);
    if (transactionEntity != null)
    {
      var transactionDto = _mapper.Map<Transaction, TransactionDto>(transactionEntity);
      return Ok(transactionDto);
    }
    return NotFound();
  }

  [HttpGet("get-all")]
  public IActionResult GetAllTransaction()
  {
    return Ok("transaction-all");
  }

  [HttpGet("get-all-data")]
  public IActionResult GetAllData()
  {
    List<Transaction> transactionList = _transactionServices.FindAll();
    return Ok(transactionList);
  }
}