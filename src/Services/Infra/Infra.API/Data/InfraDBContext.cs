using Infra.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.API.Data
{
    public class InfraDBContext : DbContext, IInfraDBContext
    {
        public string DbPath { get; }


        public InfraDBContext(DbContextOptions<InfraDBContext> options) : base(options)
        {
            InfraDBContextSeed.SeedData(this);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            
        }

        //public InfraDBContext(IConfiguration configuration )
        //{
            
        //    DbPath = configuration.GetConnectionString("InfraDBName");
        //    Console.WriteLine($"Batabase Name is {DbPath}");
        //    //InfraDBContextSeed.SeedData(this);
        //}

        public DbSet<Server> Servers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<GlobalEnvironment> GlobalEnvironments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            
            //options.UseSqlite($"Data Source = {DbPath}");
        }
    }
}
