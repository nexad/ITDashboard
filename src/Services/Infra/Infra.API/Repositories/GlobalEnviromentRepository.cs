using Infra.API.Data;
using Infra.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.API.Repositories
{
    public class GlobalEnviromentRepository : IGlobalEnviromentRepository
    {
        private readonly IInfraDBContext _context;

        public GlobalEnviromentRepository(IInfraDBContext context)
        {
            _context = context;
        }

        public Task<bool> CreateGlobalEnviroment(GlobalEnvironment globalEnvironment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGlobalEnviroment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GlobalEnvironment> GetGlobalEnvironmentById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GlobalEnvironment>> GetPreconfiguredGlobalEnvironments()
        {
            
             //var ges = await _context.GlobalEnvironments.Include("Servers").ToListAsync();
            //var ges = await _context.GlobalEnvironments.Include(g => g.Servers).Select(s=> s.)
            //var ges = await _context.GlobalEnvironments.ToListAsync();
            return await _context.GlobalEnvironments.Include(ge => ge.Servers).ToListAsync();
        }

        public Task<bool> UpdateGlobalEnviroment(GlobalEnvironment globalEnvironment)
        {
            throw new NotImplementedException();
        }
    }
}
