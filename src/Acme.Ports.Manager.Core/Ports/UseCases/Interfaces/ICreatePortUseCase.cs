using System.Threading.Tasks;
using Acme.Ports.Manager.Core.Dtos;
using Acme.Ports.Manager.Core.Ports.Commands;

namespace Acme.Ports.Manager.Core.Ports.UseCases.Interfaces
{
    public interface ICreatePortUseCase
    {
        Task<PortDto> Create(CreatePortCommand command);
    }
}