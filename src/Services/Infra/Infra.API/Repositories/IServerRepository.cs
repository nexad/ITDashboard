using Infra.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.API.Repositories
{
    public interface IServerRepository
    {
        Task<IEnumerable<Server>> GetServers();
        Task<Server> GetServerById(int id);
        Task<bool> CreateServer(Server server);
        Task<bool> DeleteServer(int id);
        Task<bool> UpdateServer(Server server);
    }
}
