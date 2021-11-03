using System.Reflection;
using Acme.Ports.Manager.Core.Commands.Ports;
using Autofac;
using MediatR;

namespace Acme.PortsManager.Infrastructure.IoC
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();
            
            builder.RegisterAssemblyTypes(typeof(CreatePortCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            
            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => componentContext.TryResolve(t, out var o) ? o : null;
            });
        }
    }
}