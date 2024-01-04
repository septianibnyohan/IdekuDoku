using System.Transactions;

namespace IdekuDoku.Domain.Repositories;

public interface ITransactionRepository
{
  Transaction GetTransactionById(int transactionId);
  // Other transaction-related methods
}