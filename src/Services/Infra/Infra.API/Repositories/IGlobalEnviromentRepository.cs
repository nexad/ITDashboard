using Infra.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.API.Repositories
{
    public interface IGlobalEnviromentRepository
    {
        Task<IEnumerable<GlobalEnvironment>> GetPreconfiguredGlobalEnvironments();
        Task<GlobalEnvironment> GetGlobalEnvironmentById(int id);
        Task<bool> CreateGlobalEnviroment(GlobalEnvironment globalEnvironment);
        Task<bool> DeleteGlobalEnviroment(int id);
        Task<bool> UpdateGlobalEnviroment(GlobalEnvironment globalEnvironment);

        


    }
}
