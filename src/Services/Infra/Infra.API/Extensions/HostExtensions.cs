using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;

namespace Infra.API.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host, int? retry=0)
        {
            int retryForAvailability = retry.Value;

            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuraion = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContext>>();

                try
                {
                    logger.LogInformation("Migrating postresql database.");

                    using var connection = new NpgsqlConnection(configuraion.GetValue<string>("DatabaseSettings:ConnectionString"));
                    connection.Open();

                    using var command = new NpgsqlCommand
                    {
                        Connection = connection
                    };


                   // command.CommandText = "ALTER TABLE Servers DROP CONSTRAINT FK_Servers_GlobalEnvironments_GlobalEnvironmentId";

                    //command.CommandText = "DROP TABLE IF EXISTS GlobalEnvironments";
                    //command.ExecuteNonQuery();

                    command.CommandText = @"CREATE TABLE IF NOT EXISTS GlobalEnvironments (
                                            Id SERIAL PRIMARY KEY NOT NULL,
                                            Description TEXT NULL,
                                            Name TEXT NULL
                                            )";
                    command.ExecuteNonQuery();

                    //command.CommandText = "DROP TABLE IF EXISTS Servers";

                    command.CommandText = @"CREATE TABLE IF NOT EXISTS Servers (
                                            Id SERIAL PRIMARY KEY NOT NULL,
                                            Description TEXT NULL,
                                            FQDN TEXT NULL,
                                            GlobalEnvironmentId INTEGER NULL,
                                            Name TEXT NULL,
                                            CONSTRAINT  FK_Servers_GlobalEnvironments_GlobalEnvironmentId
                                                FOREIGN KEY(GlobalEnvironmentId) 
	                                            REFERENCES GlobalEnvironments(Id)
	                                            ON DELETE RESTRICT
                                            )";
                    command.ExecuteNonQuery();

                    //command.CommandText = "ALTER TABLE Servers ADD CONSTRAINT FK_Servers_GlobalEnvironments_GlobalEnvironmentId FOREIGN KEY(GlobalEnvironmentId) REFERENCES GlobalEnvironments(Id) ON DELETE RESTRICT; ";



                    // command.CommandText = "INSERT INTO GlobalEnvironments (Description,Name) VALUES('Production Environment','Production');";
                    //command.ExecuteNonQuery();

                    //command.CommandText = "INSERT INTO GlobalEnvironments (Description,Name) VALUES('UAT Enfironment','UAT');";
                    //command.ExecuteNonQuery();



                    logger.LogInformation("Migrated postresql database");
                }
                catch (Exception e)
                {

                    logger.LogError(e, "Error occured during posresql database migration");

                    if (retryForAvailability < 50)
                    {
                        retryForAvailability++;
                        System.Threading.Thread.Sleep(2000);
                        MigrateDatabase<TContext>(host, retryForAvailability);
                    }

                }

            }
            return host;

        }

        private static void ExecuteMigrations(IConfiguration configuration)
        {
            using var connection = new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            connection.Open();

            using var command = new NpgsqlCommand
            {
                Connection = connection
            };

            command.CommandText = "DROP TABLE IF EXISTS Coupon";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE Coupon(Id SERIAL PRIMARY KEY, 
                                                                ProductName VARCHAR(24) NOT NULL,
                                                                Description TEXT,
                                                                Amount INT)";
            command.ExecuteNonQuery();


            command.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES('IPhone X', 'IPhone Discount', 150);";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES('Samsung 10', 'Samsung Discount', 100);";
            command.ExecuteNonQuery();
        }
    }
}

