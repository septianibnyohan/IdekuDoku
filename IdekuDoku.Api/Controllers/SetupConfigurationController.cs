using IdekuDoku.Models.Dto.Va;
using IdekuDoku.Api.Services.Va;
using IdekuDoku.Domain.Entities;
using IdekuDoku.Models.Dto.Va;
using Microsoft.AspNetCore.Mvc;

namespace IdekuDoku.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SetupConfigurationController : ControllerBase
{
    private readonly SetupConfigurationVaServices _setupConfigurationServices;

    public SetupConfigurationController(SetupConfigurationVaServices setupConfigurationServices)
    {
        this._setupConfigurationServices = setupConfigurationServices;
    }

    [HttpPost]
    [Route("")]
    public IActionResult SetConfiguration([FromBody] SetupConfigurationDto setupConfigurationDto)
    {
        try
        {
            SetupConfigurationVa setupConfigurationEntity = new SetupConfigurationVa
            {
                Id = setupConfigurationDto.Id,
                ClientId = setupConfigurationDto.ClientId,
                SharedKey = setupConfigurationDto.SharedKey,
                Environment = setupConfigurationDto.Environment
            };

            setupConfigurationEntity = _setupConfigurationServices.Create(setupConfigurationEntity);

            SetupConfigurationDto responseDto = new SetupConfigurationDto
            {
                Id = setupConfigurationEntity.Id,
                ClientId = setupConfigurationEntity.ClientId,
                SharedKey = setupConfigurationEntity.SharedKey,
                Environment = setupConfigurationEntity.Environment
            };

            return Ok(responseDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet]
    [Route("")]
    public IActionResult GetDataConfiguration()
    {
        try
        {
            SetupConfigurationDto setupConfigurationDto = new SetupConfigurationDto();
            SetupConfigurationVa? setupConfigurationEntity = _setupConfigurationServices.FindOne();

            if (setupConfigurationEntity != null)
            {
                setupConfigurationDto.Id = setupConfigurationEntity.Id;
                setupConfigurationDto.ClientId = setupConfigurationEntity.ClientId;
                setupConfigurationDto.SharedKey = setupConfigurationEntity.SharedKey;
                setupConfigurationDto.Environment = setupConfigurationEntity.Environment;
            }

            return Ok(setupConfigurationDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}