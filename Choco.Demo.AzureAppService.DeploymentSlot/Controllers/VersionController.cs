using Microsoft.AspNetCore.Mvc;

namespace Choco.Demo.AzureAppService.DeploymentSlot.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class VersionController : ControllerBase
{
    private readonly ILogger<VersionController> _logger;

    private readonly IConfiguration _configuration;

    public VersionController(ILogger<VersionController> logger, IConfiguration configuration)
    {
        _logger        = logger;
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return new OkObjectResult(new
        {
            Version  = _configuration["Version"],
            AppSlot  = _configuration[ConfigKey.AppSlot],
            AppMode  = _configuration[ConfigKey.AppMode],
            LoadData = _configuration[ConfigKey.TestKeyLoadData]
        });
    }
}