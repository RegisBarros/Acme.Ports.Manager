using System.Threading.Tasks;
using Acme.Ports.Manager.Core.Commands.Ports;
using Acme.Ports.Manager.Core.Dtos;
using Acme.Ports.Manager.Core.UseCases;
using Acme.Ports.Manager.Core.UseCases.Interfaces;
using Xunit;

namespace Acme.Ports.Manager.Tests.UseCases
{
    public class CreatePortUseCaseTest
    {
        private ICreatePortUseCase _createPortUseCase;

        [Fact]
        public async Task ShouldCreatePortSuccessfully()
        {
            var command = new CreatePortCommand("Shangai");
            _createPortUseCase = new CreatePortUseCase();

            PortDto port = await _createPortUseCase.Create(command);
            
            Assert.NotNull(port);
        }
    }
}