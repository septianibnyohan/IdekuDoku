using IdekuDoku.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdekuDoku.Domain.Repositories;

public class SetupConfigurationVaRepository
{
  private readonly IdekuDokuContext _dbContext;

  public SetupConfigurationVaRepository()
  {
    _dbContext = new IdekuDokuContext();
  }

  public SetupConfigurationVaRepository(IdekuDokuContext dbContext)
  {
    _dbContext = dbContext;
  }

  public SetupConfigurationVa? FindOne()
  {
    return _dbContext.Set<SetupConfigurationVa>().FirstOrDefault();
  }
  
  public SetupConfigurationVa Save(SetupConfigurationVa setupConfiguration)
  {
    if (setupConfiguration.Id == 0)
    {
      _dbContext.SetupConfigurationVas.Add(setupConfiguration);
    }
    else
    {
      _dbContext.SetupConfigurationVas.Update(setupConfiguration);
    }
    _dbContext.SaveChanges();
    return setupConfiguration;
  }
}