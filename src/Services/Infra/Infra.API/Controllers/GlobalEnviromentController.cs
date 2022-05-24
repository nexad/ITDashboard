using Infra.API.Entities;
using Infra.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Infra.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GlobalEnviromentController : ControllerBase
    {
        private readonly IGlobalEnviromentRepository _repository;
        private readonly ILogger<GlobalEnviromentController> _logger;

        public GlobalEnviromentController(IGlobalEnviromentRepository repository, ILogger<GlobalEnviromentController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GlobalEnvironment>>> GetGlobalEnviroments()
        {
            var ges = await _repository.GetPreconfiguredGlobalEnvironments();
            return Ok(ges);
        }

    }
}
