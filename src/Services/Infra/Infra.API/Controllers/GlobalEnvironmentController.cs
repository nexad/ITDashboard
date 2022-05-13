using Infra.API.Entities;
using Infra.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Infra.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GlobalEnvironmentController : ControllerBase
    {
        private readonly IGlobalEnviromentRepository _repository;

        public GlobalEnvironmentController(IGlobalEnviromentRepository repository)
        {
            _repository = repository;
           
        }

        #region GlobalEnvironments CRUD

        [HttpGet]
        public async Task<IEnumerable<GlobalEnvironment>> GetGlobalEnviroments()
        {
            
            return await _repository.GetPreconfiguredGlobalEnvironments();
        }

        [HttpGet("{id}",Name = "Get GlobalEnvironment")]
        [ProducesResponseType(typeof(GlobalEnvironment), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GlobalEnvironment>> GetGlobalEnvironmentById(int id)
        {
            var GlobalEnvironment =await _repository.GetGlobalEnvironmentById(id);
            return Ok(GlobalEnvironment);
        }

        [HttpDelete("{id}", Name = "Delete GlobalEnvironment")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteGlobalEnvironment(int id)
        {
            return Ok(await _repository.DeleteGlobalEnviroment(id));
            
        }

        [HttpPut]
        [ProducesResponseType(typeof(GlobalEnvironment), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GlobalEnvironment>> UpdateGlobalEnvironment([FromBody] GlobalEnvironment globale)
        {
            return Ok(await _repository.UpdateGlobalEnviroment(globale));
        }

        [HttpPost]
        [ProducesResponseType(typeof(GlobalEnvironment), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GlobalEnvironment>> CreateGlobalEnvironment([FromBody] GlobalEnvironment globale)
        {
            return Ok(await _repository.CreateGlobalEnviroment(globale));
        }

        #endregion;


    }
}
