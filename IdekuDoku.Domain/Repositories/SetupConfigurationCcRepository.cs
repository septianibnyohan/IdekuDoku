using IdekuDoku.Domain.Entities;

namespace IdekuDoku.Domain.Repositories;

public class SetupConfigurationCcRepository
{
  private readonly IdekuDokuContext _dbContext;

  public SetupConfigurationCcRepository()
  {
    _dbContext = new IdekuDokuContext();
  }

  public SetupConfigurationCcRepository(IdekuDokuContext dbContext)
  {
    this._dbContext = dbContext;
  }

  public SetupConfigurationCc? FindOne()
  {
    return _dbContext.Set<SetupConfigurationCc>().FirstOrDefault();
  }
  
  public SetupConfigurationCc Save(SetupConfigurationCc setupConfiguration)
  {
    if (setupConfiguration.Id == 0)
    {
      // Entity is new, so add it
      _dbContext.Set<SetupConfigurationCc>().Add(setupConfiguration);
    }
    else
    {
      // Entity exists, so update it
      _dbContext.Set<SetupConfigurationCc>().Update(setupConfiguration);
    }

    _dbContext.SaveChanges();

    return setupConfiguration;
  }
}