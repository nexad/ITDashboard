using Infra.API.Entities;
using Infra.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Infra.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ServerController : ControllerBase
    {
        private readonly IServerRepository _repository;

        public ServerController(IServerRepository repository)
        {
            _repository = repository;

        }


        [HttpGet]
        public async Task<IEnumerable<Server>> GetServers()
        {

            return await _repository.GetServers();
        }



        [HttpGet("{id}", Name = "Get Server")]
        [ProducesResponseType(typeof(Server), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Server>> GetServerById(int id)
        {
            var server = await _repository.GetServerById(id);
            return Ok(server);
        }
    }
}
