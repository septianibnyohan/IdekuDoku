using IdekuDoku.Domain.Entities;

namespace IdekuDoku.Domain.Repositories;

public interface ITransactionCcRepository
{
  TransactionCc? GetById(int id);

  List<TransactionCc?> GetAll();

  void Add(TransactionCc? entity);

  void Update(TransactionCc? entity);

  void Delete(TransactionCc? entity);
}

public class TransactionCcRepository : ITransactionCcRepository
{
  private readonly IdekuDokuContext dbContext; // Replace YourDbContext with your actual DbContext class

  public TransactionCcRepository(IdekuDokuContext dbContext)
  {
    this.dbContext = dbContext;
  }

  public TransactionCc? GetById(int id)
  {
    return dbContext.TransactionCcs.FirstOrDefault(t => t.Id == id);
  }

  public List<TransactionCc?> GetAll()
  {
    return dbContext.TransactionCcs.ToList();
  }

  public void Add(TransactionCc? entity)
  {
    dbContext.TransactionCcs.Add(entity);
    dbContext.SaveChanges();
  }

  public void Update(TransactionCc? entity)
  {
    dbContext.TransactionCcs.Update(entity);
    dbContext.SaveChanges();
  }

  public void Delete(TransactionCc? entity)
  {
    dbContext.TransactionCcs.Remove(entity);
    dbContext.SaveChanges();
  }
}