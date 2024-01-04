using IdekuDoku.Domain.Entities;
using IdekuDoku.Domain.Repositories;
using IdekuDoku.Models.Dto.Cc.Response;

namespace IdekuDoku.Api.Services.Cc;

public class TransactionCcServices
{
  private readonly ITransactionCcRepository _transactionCcRepository; // Replace with your actual repository interface

  public TransactionCcServices(ITransactionCcRepository transactionCcRepository)
  {
    this._transactionCcRepository = transactionCcRepository;
  }

  public TransactionCc? Create(PaymentTokenResponseDto? paymentTokenResponseDto)
  {
    var transactionCc = new TransactionCc
    {
      InvoiceNumber = paymentTokenResponseDto.Order.InvoiceNumber,
      Amount = paymentTokenResponseDto.Order.Amount,
      Status = "pending",
      UrlPaymentPage = paymentTokenResponseDto.CreditCardPaymentPage.Url,
    };

    _transactionCcRepository.Add(transactionCc); // Assuming it returns void or success indication

    // Retrieve the entity from the database, e.g., by its ID
    // You'll need to modify this part based on your specific database access method.
    var addedTransactionCc = _transactionCcRepository.GetById(transactionCc.Id); // Replace with your retrieval method.

    return addedTransactionCc;
  }
}