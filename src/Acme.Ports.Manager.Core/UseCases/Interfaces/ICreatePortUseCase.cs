using System.Threading.Tasks;
using Acme.Ports.Manager.Core.Commands.Ports;
using Acme.Ports.Manager.Core.Dtos;

namespace Acme.Ports.Manager.Core.UseCases.Interfaces
{
    public interface ICreatePortUseCase
    {
        Task<PortDto> Create(CreatePortCommand command);
    }
}