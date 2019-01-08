using System.Collections.Generic;
using Ticketing.API.Models;
using Ticketing.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Ticketing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigMapController : ControllerBase
    {
        private IOptionsSnapshot<AppConfiguration> _appSettings;
        public ConfigMapController(IOptionsSnapshot<AppConfiguration> appSettings)
        {
            _appSettings = appSettings;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string>()
            {
                $"ValueFromAppSettings: {_appSettings.Value.ValueFromAppSettings}",
                $"ValueFromKubernetesEnvVariableValue: {_appSettings.Value.ValueFromKubernetesEnvVariable}",
                $"ValueOverride: {_appSettings.Value.ValueOverride}"
            };
        }
    }
}