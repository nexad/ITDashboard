using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.API.Data
{
    public interface IInfraDBContext
    {
        DbSet<Server> Servers { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<ServiceType> ServiceTypes { get; set; }
        DbSet<Solution> Solutions { get; set; }
        DbSet<GlobalEnvironment> GlobalEnvironments { get; set; }



    }
}
