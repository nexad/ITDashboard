using Infra.API.Data;
using Infra.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private IInfraDBContext _dbContext;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IInfraDBContext infraDBContext)
        {
            _logger = logger;
            _dbContext = infraDBContext;
        }

        [HttpGet]
        public IEnumerable<Server> Get()
        {
            return _dbContext.Servers.ToArray();
        }
    }
}
