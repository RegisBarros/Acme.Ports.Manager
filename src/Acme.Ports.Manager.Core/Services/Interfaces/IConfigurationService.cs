using Microsoft.Extensions.Configuration;

namespace Acme.Ports.Manager.Core.Services.Interfaces
{
    public interface IConfigurationService
    {
        IConfiguration GetConfiguration();
    }
}