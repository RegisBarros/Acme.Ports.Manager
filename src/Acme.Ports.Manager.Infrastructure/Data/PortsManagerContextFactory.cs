using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

// https://blog.tonysneed.com/2018/12/20/idesigntimedbcontextfactory-and-dependency-injection-a-love-story/

namespace Acme.Ports.Manager.Infrastructure.Data
{
    public class PortsManagerContextFactory : IDesignTimeDbContextFactory<PortsManagerContext>
    {
        public PortsManagerContext CreateDbContext(string[] args)
        {
            var configuration = GetConfiguration();

            var builder = new DbContextOptionsBuilder<PortsManagerContext>();
 
            var connectionString = configuration.GetConnectionString(nameof(PortsManagerContext));
 
            builder.UseNpgsql(connectionString);
 
            return new PortsManagerContext(builder.Options);
        }

        private static IConfigurationRoot GetConfiguration()
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
            return configuration;
        }
    }
}