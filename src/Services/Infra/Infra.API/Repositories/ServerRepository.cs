using Infra.API.Data;
using Infra.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.API.Repositories
{
    public class ServerRepository : IServerRepository
    {
        private readonly IInfraDBContext _context;

        public ServerRepository(IInfraDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Server>> GetPreconfiguredServers()
        {

            return await _context.Servers.Include(s => s.GlobalEnvironment).ToListAsync();
        }
    }
}
