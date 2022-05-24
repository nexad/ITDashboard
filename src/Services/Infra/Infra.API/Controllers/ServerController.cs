using Infra.API.Entities;
using Infra.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Infra.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ServerController : ControllerBase
    {
        private readonly IServerRepository _repository;
        private readonly ILogger<GlobalEnviromentController> _logger;

        public ServerController(IServerRepository repository, ILogger<GlobalEnviromentController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Server>>> GetServers()
        {
            var servers = await _repository.GetPreconfiguredServers();
            return Ok(servers);
        }


    }
}
