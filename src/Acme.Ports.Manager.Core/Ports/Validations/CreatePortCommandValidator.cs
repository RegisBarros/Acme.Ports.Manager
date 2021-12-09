using Acme.Ports.Manager.Core.Ports.Commands;
using FluentValidation;

namespace Acme.Ports.Manager.Core.Ports.Validations
{
    public class CreatePortCommandValidator : AbstractValidator<CreatePortCommand>
    {
        public CreatePortCommandValidator()
        {
            RuleFor(command => command.Name).NotEmpty().WithMessage("Please specify a name");
        }
    }
}
