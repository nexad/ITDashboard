using Microsoft.AspNetCore.Mvc;

namespace DWHProxy.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet("health")]
        [Produces("text/plain")]
        public async Task<object> GetHealthStatusInfo()
        {
            return Ok("UP");
        }
    }
}
