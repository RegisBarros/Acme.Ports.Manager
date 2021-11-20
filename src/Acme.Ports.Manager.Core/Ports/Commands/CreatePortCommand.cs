using Acme.Ports.Manager.Core.Dtos;
using MediatR;

namespace Acme.Ports.Manager.Core.Ports.Commands
{
    public class CreatePortCommand : IRequest<PortDto>
    {
        public CreatePortCommand() { }
        
        public CreatePortCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}