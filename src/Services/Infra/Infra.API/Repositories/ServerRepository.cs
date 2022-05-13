using Dapper;
using Infra.API.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.API.Repositories
{
    public class ServerRepository : IServerRepository
    {
        private readonly IConfiguration _configuration;

        public ServerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> CreateServer(Server server)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteServer(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Server> GetServerById(int id)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));



            var server= await connection.QueryFirstOrDefaultAsync<Server>
                ("select * from Servers where Id =  @Id", new { Id = id });


            if (server == null)
            {
                server = new Server();
            }

            return server;
        }

        public async Task<IEnumerable<Server>> GetServers()
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var servers = await connection.QueryAsync<Server>("select * from Servers");
            return servers;
        }

        public async Task<bool> UpdateServer(Server server)
        {

            throw new System.NotImplementedException();

            //using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            //var rows = await connection.ExecuteAsync("UPDATE Server SET Description = @Description,Name=@Name,FQDN = @FQDN,", new { Description = globalEnvironment.Description, Name = globalEnvironment.Name });

            //if (rows == 0) { return false; }
            //return true;
        }
    }
}
