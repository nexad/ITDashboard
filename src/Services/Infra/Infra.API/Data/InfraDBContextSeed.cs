using Infra.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.API.Data
{
    public class InfraDBContextSeed
    {
        public static void SeedData(InfraDBContext infraDBContext)
        {
            if (!infraDBContext.GlobalEnvironments.Select(p => true).Any())
            {
                Console.WriteLine("Seed data START");

                infraDBContext.GlobalEnvironments.AddRangeAsync(
                    GetPreconfiguredGlobalEnvironments()
                    );

                infraDBContext.SaveChanges();

                var environment = infraDBContext.GlobalEnvironments.FirstOrDefault(p => p.Name.Equals("UAT"));

                if (environment != null)
                {
                    
                    Console.WriteLine("UAT Environment found");
                    environment.Servers.AddRange(GetPreconfiguredUATServers(environment));



                    infraDBContext.Solutions.AddRangeAsync(GetPreconfiguredSolutionss());

                    infraDBContext.SaveChanges();
                }
                
            }    
        }
        public static IEnumerable<GlobalEnvironment> GetPreconfiguredGlobalEnvironments()
        {
            return new List<GlobalEnvironment>()
            {
                new GlobalEnvironment
                {
                    Name = "Production",
                    Description = "Production Environment",
                    Servers = new List<Server>()
                },
                new GlobalEnvironment
                {
                    Name = "UAT",
                    Description = "UAT Enfironment",
                    Servers = new List<Server>()

                },
            };
        }

        public static IEnumerable<Solution> GetPreconfiguredSolutionss()
        {
            return new List<Solution>()
            {
                new Solution
                {
                    Name = "IPS",
                    Description = "Instant Payment System"
                }
            };
        }
        public static IEnumerable<Server> GetPreconfiguredUATServers(GlobalEnvironment globalEnvironment)
        {
            return new List<Server>()
            {
                new Server
                {
                    Name = "IPSAPPSRVUAT",
                    Description = "IPS UAT Server, Control panel and first backgroun service",
                    GlobalEnvironment = globalEnvironment
                },
                new Server
                {
                    Name = "IPSAPPSRVUAT1",
                    Description = "IPS UAT Server, Second background service and API Service",
                    GlobalEnvironment = globalEnvironment
                },
                new Server
                {
                    Name = "IPSAPPSRVUAT2",
                    Description = "IPS UAT Server, API Service",
                    GlobalEnvironment = globalEnvironment
                },
            };
        }
    }
}
