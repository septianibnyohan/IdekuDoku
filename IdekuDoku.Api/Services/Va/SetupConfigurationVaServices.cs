using IdekuDoku.Domain.Entities;
using IdekuDoku.Domain.Repositories;

namespace IdekuDoku.Api.Services.Va;

public class SetupConfigurationVaServices
{
  private readonly SetupConfigurationVaRepository _setupConfigurationRepository;
  
  public SetupConfigurationVaServices()
  {
    this._setupConfigurationRepository = new SetupConfigurationVaRepository();
  }

  public SetupConfigurationVaServices(SetupConfigurationVaRepository setupConfigurationRepository)
  {
    this._setupConfigurationRepository = setupConfigurationRepository;
  }

  public SetupConfigurationVa Create(SetupConfigurationVa setupConfiguration)
  {
    SetupConfigurationVa? existingConfiguration = FindOne();
    if (existingConfiguration != null)
    {
      //setupConfiguration.Id = existingConfiguration.Id;
      existingConfiguration.MerchantName = setupConfiguration.MerchantName;
      existingConfiguration.ClientId = setupConfiguration.ClientId;
      existingConfiguration.SharedKey = setupConfiguration.SharedKey;
      existingConfiguration.Environment = setupConfiguration.Environment;
      
      return _setupConfigurationRepository.Save(existingConfiguration);
    }

    return _setupConfigurationRepository.Save(setupConfiguration);

  }

  public SetupConfigurationVa? FindOne()
  {
    return _setupConfigurationRepository.FindOne();
  }
}