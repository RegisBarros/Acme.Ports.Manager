using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Acme.Ports.Manager.Core.Ports.Exceptions;
using FluentValidation;
using MediatR;

namespace Acme.Ports.Manager.Core.Ports.Behaviors
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;

        public ValidatorBehavior(IValidator<TRequest>[] validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
                throw new PortDomainException($"Command Validation Errors for type {typeof(TRequest).Name}", new ValidationException("Validation exception", failures));

            return next();
        }
    }
}
