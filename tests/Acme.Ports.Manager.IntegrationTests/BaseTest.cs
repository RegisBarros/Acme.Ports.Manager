using System.Linq;
using System.Net.Http;
using Acme.Ports.Manager.Api;
using Acme.Ports.Manager.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Acme.Ports.Manager.IntegrationTests
{
    public class BaseTest
    {
        protected readonly HttpClient Client;

        public BaseTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(
                            d => d.ServiceType ==
                                 typeof(DbContextOptions<PortsManagerContext>));

                        services.Remove(descriptor);
                        // services.RemoveAll(typeof(PortsManagerContext));
                        services.AddDbContext<PortsManagerContext>(options =>
                        {
                            options.UseInMemoryDatabase("PortsManagerDb");
                        });
                    });
                });

            Client = appFactory.CreateClient();
        }
    }
}