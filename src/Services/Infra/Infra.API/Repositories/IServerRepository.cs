using Infra.API.Entities;

namespace Infra.API.Repositories
{
    public interface IServerRepository
    {
        Task<IEnumerable<Server>> GetPreconfiguredServers();
        

    }
}
