using IdekuDoku.Domain.Entities;
using IdekuDoku.Domain.Repositories;

namespace IdekuDoku.Api.Services.Cc;

public class SetupConfigurationCcServices
{
  private readonly SetupConfigurationCcRepository _setupConfigurationCcRepository;

  public SetupConfigurationCcServices(SetupConfigurationCcRepository setupConfigurationCcRepository)
  {
    this._setupConfigurationCcRepository = setupConfigurationCcRepository;
  }

  public SetupConfigurationCc Create(SetupConfigurationCc setupConfiguration)
  {
    return _setupConfigurationCcRepository.Save(setupConfiguration);
  }

  public SetupConfigurationCc? FindOne()
  {
    return _setupConfigurationCcRepository.FindOne();
  }
}