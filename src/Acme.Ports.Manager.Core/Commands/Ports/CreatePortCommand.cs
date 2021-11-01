using Acme.Ports.Manager.Core.Dtos;
using MediatR;

namespace Acme.Ports.Manager.Core.Commands.Ports
{
    public class CreatePortCommand : IRequest<PortDto>
    {
        public CreatePortCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}