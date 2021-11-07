using System;
using System.IO;
using Acme.Ports.Manager.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Acme.Ports.Manager.Infrastructure
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly string _currentDirectory;

        private readonly string _environment;

        public ConfigurationService()
        {
            _environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            _currentDirectory = Directory.GetCurrentDirectory();
        }
        
        public IConfiguration GetConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(_currentDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{_environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            return configuration;
        }

    }
}