using Acme.Ports.Manager.Core.Repositories;
using Acme.Ports.Manager.Core.Services.Interfaces;
using Acme.Ports.Manager.Infrastructure;
using Acme.Ports.Manager.Infrastructure.Data;
using Acme.Ports.Manager.Infrastructure.Data.Repositories;
using Autofac;

namespace Acme.PortsManager.Infrastructure.IoC
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConfigurationService>()
                .As<IConfigurationService>()
                .SingleInstance();
                
            builder.RegisterType<PortRepository>()
                .As<IPortRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PortsManagerContext>()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}