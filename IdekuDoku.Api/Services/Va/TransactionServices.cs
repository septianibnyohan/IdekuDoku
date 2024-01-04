using IdekuDoku.Models.Dto.Va;
using IdekuDoku.Models.Dto.Va.Payment.Response;
using IdekuDoku.Domain.Entities;

namespace IdekuDoku.Api.Services.Va;

public class TransactionServices : ITransactionServices
{
  private readonly IdekuDokuContext _dbContext;
    
  /*
  public TransactionServices()
  {
      this._dbContext = new IdekuDokuApiContext();
  }
  */
    
  public TransactionServices(IdekuDokuContext dbContext)
  {
    this._dbContext = dbContext;
  }

  public Transaction Create(PaymentResponseDto paymentResponseDto, PaymentCodeInboundDto paymentCodeInboundDto)
  {
    var transaction = new Transaction
    {
      InvoiceNumber = paymentResponseDto.Order.InvoiceNumber,
      VirtualAccountNumber = paymentResponseDto.VirtualAccountInfo.VirtualAccountNumber,
      ExpiredDate = paymentResponseDto.VirtualAccountInfo.ExpiredDate,
      HowToPayApi = paymentResponseDto.VirtualAccountInfo.HowToPayApi,
      HowToPayPage = paymentResponseDto.VirtualAccountInfo.HowToPayPage,
      Status = "pending",
      Address = paymentCodeInboundDto.Address,
      Province = paymentCodeInboundDto.Province,
      Country = paymentCodeInboundDto.Country,
      PhoneNumber = paymentCodeInboundDto.PhoneNumber,
      CustomerName = paymentCodeInboundDto.CustomerName,
      PostalCode = paymentCodeInboundDto.PostalCode
    };

    _dbContext.Transactions.Add(transaction);
    _dbContext.SaveChanges();

    return transaction;
  }

  public List<Transaction> FindAll()
  {
    return _dbContext.Transactions.ToList();
  }

  public Transaction? FindByVANumber(string vaNumber)
  {
    return _dbContext.Transactions.First(trx => trx.VirtualAccountNumber == vaNumber);
  }

  public void UpdateByVANumber(string vaNumber)
  {
    var transaction = _dbContext.Transactions.FirstOrDefault(trx => trx.VirtualAccountNumber == vaNumber);
    if (transaction != null)
    {
      transaction.Status = "success";
      _dbContext.SaveChanges();
    }
  }
}