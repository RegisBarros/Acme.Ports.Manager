using System.Reflection;
using Acme.Ports.Manager.Core.Ports.Behaviors;
using Acme.Ports.Manager.Core.Ports.Commands;
using Acme.Ports.Manager.Core.Ports.Validations;
using Autofac;
using FluentValidation;
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

            builder.RegisterAssemblyTypes(typeof(CreatePortCommandValidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}