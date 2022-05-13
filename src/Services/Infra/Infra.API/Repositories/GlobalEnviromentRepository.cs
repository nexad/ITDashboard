using Dapper;
using Infra.API.Data;
using Infra.API.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infra.API.Repositories
{
    public class GlobalEnviromentRepository : IGlobalEnviromentRepository
    {
        private readonly IInfraDBContext _context;
        private readonly IConfiguration _configuration;

        public GlobalEnviromentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> CreateGlobalEnviroment(GlobalEnvironment globalEnvironment)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var rows = await connection.ExecuteAsync("INSERT INTO GlobalEnvironments (Description,Name) VALUES(@Description,@Name)", new { Description = globalEnvironment.Description, Name = globalEnvironment.Name });

            if (rows == 0) { return false; }
            return true;
        }

        public async Task<bool> DeleteGlobalEnviroment(int id)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var rows = await connection.ExecuteAsync("delete from GlobalEnvironments where Id = @Id", new { Id = id });

            if (rows == 0) { return false; }
            return true;
            
        }

        public  async Task<GlobalEnvironment> GetGlobalEnvironmentById(int id)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            

            var GlobalEnvironment = await connection.QueryFirstOrDefaultAsync<GlobalEnvironment>
                ("select * from GlobalEnvironments where Id =  @Id", new { Id = id });


            if (GlobalEnvironment == null)
            {
                GlobalEnvironment = new GlobalEnvironment();
            }

            return GlobalEnvironment;   

        }

        public async Task<IEnumerable<GlobalEnvironment>> GetPreconfiguredGlobalEnvironments()
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var lstGe = await connection.QueryAsync<GlobalEnvironment>("select * from GlobalEnvironments");
            return lstGe;
        }

        public async Task<bool> UpdateGlobalEnviroment(GlobalEnvironment globalEnvironment)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var rows = await connection.ExecuteAsync("UPDATE GlobalEnvironments SET Description = @Description,Name=@Name", new { Description = globalEnvironment.Description, Name = globalEnvironment.Name });

            if (rows == 0) { return false; }
            return true;

        }
    }
}
