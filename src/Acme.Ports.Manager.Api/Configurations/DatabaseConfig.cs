using System;
using System.Reflection;
using Acme.Ports.Manager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Acme.Ports.Manager.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentException(nameof(services));

            services.AddDbContext<PortsManagerContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString(nameof(PortsManagerContext)), npgsqlOptionsAction:
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                    }));
        }
    }
}