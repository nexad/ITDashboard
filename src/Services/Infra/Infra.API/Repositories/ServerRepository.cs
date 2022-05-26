using Infra.API.Data;
using Infra.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.API.Repositories
{
    public class ServerRepository : IServerRepository
    {
        private readonly InfraDBContext _context;

        public ServerRepository(InfraDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Server>> GetPreconfiguredServers()
        {

            return await _context.Servers.Include(s => s.GlobalEnvironment).ToListAsync();
        }

        public async Task AddServer(Server server, int globalEnvId)
        {
            var ge = _context.GlobalEnvironments.FirstOrDefault(e => e.Id == globalEnvId);
            server.GlobalEnvironment = ge;
            await _context.Servers.AddAsync(server);
            _context.SaveChanges();

        }

    }
}
