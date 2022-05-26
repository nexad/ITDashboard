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

        [HttpPost]
        public async Task<ActionResult<Server>> AddServer(string Name, string FQDN, string Description, int GlobalEnvId)
        {
            try
            {
                Server server = new Server()
                {
                    Name = Name,
                    FQDN = FQDN,
                    Description = Description,
                };

                await _repository.AddServer(server, GlobalEnvId);
                return Ok();
            }
            catch (Exception ex)
            {

                return Problem("Doslo je do greske prilikom dodavanja novog servera." + Environment.NewLine + ex.Message.ToString());
            }


        }


    }
}
