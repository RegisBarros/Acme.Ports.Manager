using System.Threading.Tasks;
using Acme.Ports.Manager.Core.Commands.Ports;
using Acme.Ports.Manager.Core.Dtos;
using Acme.Ports.Manager.Core.Models;
using Acme.Ports.Manager.Core.Repositories;
using Acme.Ports.Manager.Core.UseCases.Interfaces;
using static System.Threading.Tasks.Task;
using static Acme.Ports.Manager.Core.Mappers.PortMapper;

namespace Acme.Ports.Manager.Core.UseCases
{
    public class CreatePortUseCase : ICreatePortUseCase
    {
        private readonly IPortRepository _portRepository;

        public CreatePortUseCase(IPortRepository portRepository)
        {
            _portRepository = portRepository;
        }

        public async Task<PortDto> Create(CreatePortCommand command)
        {
            var port = Port.Create(command.Name);

            await _portRepository.Save(port);

            return await FromResult(ToDto(port)); 
        }
    }
}