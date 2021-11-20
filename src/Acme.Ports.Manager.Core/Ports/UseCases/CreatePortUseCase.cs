using System.Threading;
using System.Threading.Tasks;
using Acme.Ports.Manager.Core.Dtos;
using Acme.Ports.Manager.Core.Ports.Commands;
using Acme.Ports.Manager.Core.Ports.Repositories;
using MediatR;
using static System.Threading.Tasks.Task;
using static Acme.Ports.Manager.Core.Ports.Mappers.PortMapper;

namespace Acme.Ports.Manager.Core.Ports.UseCases
{
    public class CreatePortUseCase : IRequestHandler<CreatePortCommand, PortDto>
    {
        private readonly IPortRepository _portRepository;

        public CreatePortUseCase(IPortRepository portRepository)
        {
            _portRepository = portRepository;
        }

        public async Task<PortDto> Handle(CreatePortCommand command, CancellationToken cancellationToken)
        {
            var port = Port.Create(command.Name);

            await _portRepository.Save(port);

            return await FromResult(ToDto(port)); 
        }
    }
}