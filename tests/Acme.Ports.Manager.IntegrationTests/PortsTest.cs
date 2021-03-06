using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Acme.Ports.Manager.Core.Dtos;
using Acme.Ports.Manager.Core.Ports.Commands;
using FluentAssertions;
using Xunit;

namespace Acme.Ports.Manager.IntegrationTests
{
    public class PortsTest : BaseTest
    {
        [Fact]
        public async Task ShouldCreatePortSuccessfully()
        {
            // Arrange
            var command = new CreatePortCommand("Port of Shangai");

            // Act
            var response = await Client.PostAsJsonAsync("v1/ports", command);
            var createdPort = await response.Content.ReadFromJsonAsync<PortDto>();
            
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            createdPort.Id.Should().NotBeEmpty();
            createdPort.Name.Should().Be(command.Name);
        }

        [Fact]
        public async Task GetPorts()
        {
            var response = await Client.GetAsync("v1/ports");
            
            var bodyContent = await response.Content.ReadAsStringAsync();
            
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            bodyContent.Should().Be("Success");
        }


        [Fact]
        public async Task ShouldFailWhenRequestIsInvalid()
        {
            // Arrange
            var command = new CreatePortCommand();

            // Act 
            var response = await Client.PostAsJsonAsync("v1/ports", command);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}