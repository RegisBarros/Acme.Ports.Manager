using System.Threading;
using System.Threading.Tasks;
using Acme.Ports.Manager.Core.Dtos;
using Acme.Ports.Manager.Core.Ports;
using Acme.Ports.Manager.Core.Ports.Commands;
using Acme.Ports.Manager.Core.Ports.Repositories;
using Acme.Ports.Manager.Core.Ports.UseCases;
using Moq;
using Xunit;

namespace Acme.Ports.Manager.Tests.UseCases
{
    public class CreatePortUseCaseTest
    {
        private readonly  CreatePortUseCase _createPortUseCase;
        private readonly  Mock<IPortRepository> _portRepository = new Mock<IPortRepository>();

        public CreatePortUseCaseTest()
        {
            _createPortUseCase = new CreatePortUseCase(_portRepository.Object);
        }

        [Fact]
        public async Task ShouldCreatePortSuccessfully()
        {
            var command = new CreatePortCommand("Shangai");
            var cancelationToken = new CancellationToken();

            PortDto port = await _createPortUseCase.Handle(command, cancelationToken);
            
            _portRepository.Verify(p => p.Save(It.IsAny<Port>()), Times.Once);
            Assert.NotNull(port);
        }
    }
}